using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.Imports;
using Shopfloor.Barcode.Application.Parameters.Imports;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;


namespace Shopfloor.Barcode.Application.Query.Imports
{
    public class GetImportsQuery : IRequest<PagedResponse<IReadOnlyList<ImportModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public ImportType? Type { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public ImportStatus? Status { get; set; }

    }
    public class GetImportsQueryHandler : IRequestHandler<GetImportsQuery, PagedResponse<IReadOnlyList<ImportModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IImportRepository _repository;
        public GetImportsQueryHandler(IMapper mapper,
            IImportRepository repository)
        {
            _mapper = mapper; 
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ImportModel>>> Handle(GetImportsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ImportParameter>(request);
            validFilter.OrderBy = string.IsNullOrEmpty(validFilter.OrderBy) ? " ModifiedDate DESC " : validFilter.OrderBy;
            validFilter.SetSearchProps(new string[] { nameof(ImportParameter.Code), nameof(ImportParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ImportParameter, ImportModel>(validFilter);
        }
    }
}
