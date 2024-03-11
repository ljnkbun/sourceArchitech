using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.WfxGDNs;
using Shopfloor.Barcode.Application.Parameters.WfxGDNs;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.WfxGDNs
{
    public class GetWfxGDNsQuery : IRequest<PagedResponse<IReadOnlyList<WfxGDNParentModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }

        public ExportTypes? GDNType { get; set; }
        public string GDNTypes { get; set; }
        public DateTime? FromOrderDate { get; set; }
        public DateTime? ToOrderDate { get; set; }
        public string GDNNum { get; set; }
        public string SupplierName { get; set; }
        public string WFXArticleCode { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }

    }
    public class GetWfxGDNEntitiesQueryHandler : IRequestHandler<GetWfxGDNsQuery, PagedResponse<IReadOnlyList<WfxGDNParentModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxGDNRepository _repository;
        private readonly ILocationRepository _locationRepository;
        public GetWfxGDNEntitiesQueryHandler(IMapper mapper,
            IWfxGDNRepository repository,
            ILocationRepository locationRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _locationRepository = locationRepository;
        }

        public async Task<PagedResponse<IReadOnlyList<WfxGDNParentModel>>> Handle(GetWfxGDNsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxGDNParameter>(request);
            validFilter.GDNType = validFilter.GDNTypes.ToString();

            var rs = await _repository.GetListAsync<WfxGDNParameter, WfxGDNMasterModel>(validFilter, validFilter.FromOrderDate, validFilter.ToOrderDate);

            if (rs.Data == null) return _mapper.Map<PagedResponse<IReadOnlyList<WfxGDNParentModel>>>(rs);

            var response = new PagedResponse<IReadOnlyList<WfxGDNParentModel>>(validFilter.PageNumber, validFilter.PageSize);
            var groupByData = rs.Data.GroupBy(x => new { x.WFXArticleCode, x.GDNNum });

            var respData = new List<WfxGDNParentModel>();

            var locs = await _locationRepository.GetAllAsync();
            foreach (var entry in groupByData)
            {
                var articleModele = _mapper.Map<WfxGDNParentModel>(entry.FirstOrDefault());
                var loc = locs.FirstOrDefault(x => x.Name == articleModele.Location)?.Id;
                articleModele.LocationId = loc;
                respData.Add(articleModele);

                var lstEntityModel = rs.Data.Where(x => x.WFXArticleCode == entry.Key.WFXArticleCode && x.GDNNum == entry.Key.GDNNum);
                if (lstEntityModel.Any())
                {
                    articleModele.WfxGDNChildModels = _mapper.Map<List<WfxGDNChildModel>>(lstEntityModel);
                    foreach (var item in articleModele.WfxGDNChildModels)
                    {
                        item.LocationId = loc;
                    }
                }
            }

            response.Data = respData;

            return response;

        }
    }
}
