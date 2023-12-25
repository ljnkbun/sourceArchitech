using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.Exports;
using Shopfloor.Barcode.Application.Parameters.Exports;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.Exports
{
    public class GetExportsQuery : IRequest<PagedResponse<IReadOnlyList<ExportModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public ExportStatus? Status { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }

    }
    public class GetExportEntitiesQueryHandler : IRequestHandler<GetExportsQuery, PagedResponse<IReadOnlyList<ExportModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IExportRepository _repository;
        public GetExportEntitiesQueryHandler(IMapper mapper,
            IExportRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ExportModel>>> Handle(GetExportsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ExportParameter>(request);
            return await _repository.GetModelPagedReponseAsync<ExportParameter, ExportModel>(validFilter);
        }
    }
}
