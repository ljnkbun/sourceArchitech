using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ExportDetails
{
    public class GetExportDetailQuery : IRequest<Response<ExportDetail>>
    {
        public int Id { get; set; }
    }
    public class GetExportDetailEntityQueryHandler : IRequestHandler<GetExportDetailQuery, Response<ExportDetail>>
    {
        private readonly IExportDetailRepository _repository;
        public GetExportDetailEntityQueryHandler(IExportDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<ExportDetail>> Handle(GetExportDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            return entity == null
                ? new($"Recipe Unit Not Found (Id:{query.Id}).")
                : new Response<ExportDetail>(entity);
        }
    }
}
