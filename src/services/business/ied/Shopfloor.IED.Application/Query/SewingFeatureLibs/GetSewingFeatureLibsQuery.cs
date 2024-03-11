using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingFeatureLibs;
using Shopfloor.IED.Application.Parameters.SewingFeatureLibs;
using Shopfloor.IED.Application.Parameters.SewingOperationLibs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingFeatureLibs
{
    public class GetSewingFeatureLibsQuery : IRequest<PagedResponse<IReadOnlyList<SewingFeatureLibModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public int? SewingComponentId { get; set; }
        public decimal? LabourCost { get; set; }
        public decimal? AllowedTime { get; set; }
        public decimal? TotalSMV { get; set; }
        public int? FolderTreeId { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetSewingFeatureLibsQueryHandler : IRequestHandler<GetSewingFeatureLibsQuery, PagedResponse<IReadOnlyList<SewingFeatureLibModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingFeatureLibRepository _repository;
        public GetSewingFeatureLibsQueryHandler(IMapper mapper,
            ISewingFeatureLibRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingFeatureLibModel>>> Handle(GetSewingFeatureLibsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingFeatureLibParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SewingOperationLibParameter.Code), nameof(SewingOperationLibParameter.Name), nameof(SewingOperationLibParameter.Description) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SewingFeatureLibParameter, SewingFeatureLibModel>(validFilter);
        }
    }
}
