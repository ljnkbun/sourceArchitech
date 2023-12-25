using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ImportDetails
{
    public class GetImportDetailQuery : IRequest<Response<Domain.Entities.ImportDetail>>
    {
        public int Id { get; set; }
    }
    public class GetImportDetailQueryHandler : IRequestHandler<GetImportDetailQuery, Response<Domain.Entities.ImportDetail>>
    {
        private readonly IImportDetailRepository _repository;
        public GetImportDetailQueryHandler(
            IImportDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.ImportDetail>> Handle(GetImportDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            return entity == null
                ? throw new ApiException($"ImportDetail Not Found (Id:{query.Id}).")
                : new Response<Domain.Entities.ImportDetail>(entity);
        }
    }
}
