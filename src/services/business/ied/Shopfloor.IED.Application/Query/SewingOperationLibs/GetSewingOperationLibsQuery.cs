using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingOperationLibs;
using Shopfloor.IED.Application.Parameters.SewingOperationLibs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingOperationLibs
{
    public class GetSewingOperationLibsQuery : IRequest<PagedResponse<IReadOnlyList<SewingOperationLibModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public int? SewingComponentId { get; set; }
        public int? FolderTreeId { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? PersonalAllowance { get; set; }
        public decimal? MachineDelay { get; set; }
        public decimal? Contingency { get; set; }
        public decimal? TotalSMV { get; set; }
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
        public string CacheKey => $"SewingOperationLibs";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingOperationLibsQueryHandler : IRequestHandler<GetSewingOperationLibsQuery, PagedResponse<IReadOnlyList<SewingOperationLibModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingOperationLibRepository _repository;
        public GetSewingOperationLibsQueryHandler(IMapper mapper,
            ISewingOperationLibRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingOperationLibModel>>> Handle(GetSewingOperationLibsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingOperationLibParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SewingOperationLibParameter.Code), nameof(SewingOperationLibParameter.Name), nameof(SewingOperationLibParameter.Description) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SewingOperationLibParameter, SewingOperationLibModel>(validFilter);
        }
    }
}
