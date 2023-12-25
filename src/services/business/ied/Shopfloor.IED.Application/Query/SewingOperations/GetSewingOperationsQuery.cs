using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingOperations;
using Shopfloor.IED.Application.Parameters.SewingOperations;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingOperations
{
    public class GetSewingOperationsQuery : IRequest<PagedResponse<IReadOnlyList<SewingOperationModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? TotalTMU { get; set; }
        public decimal? NoneMachineTime { get; set; }
        public decimal? LabourCost { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingOperations";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingOperationsQueryHandler : IRequestHandler<GetSewingOperationsQuery, PagedResponse<IReadOnlyList<SewingOperationModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingOperationRepository _repository;
        public GetSewingOperationsQueryHandler(IMapper mapper,
            ISewingOperationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingOperationModel>>> Handle(GetSewingOperationsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingOperationParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SewingOperationParameter.Code), nameof(SewingOperationParameter.Name), nameof(SewingOperationParameter.Description) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SewingOperationParameter, SewingOperationModel>(validFilter);
        }
    }
}
