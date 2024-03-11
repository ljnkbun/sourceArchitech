using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.WfxGDIs
{
    public class GetWfxGDIQuery : IRequest<Response<Domain.Entities.WfxGDI>>
    {
        public int Id { get; set; }
    }
    public class GetWfxGDIQueryHandler : IRequestHandler<GetWfxGDIQuery, Response<Domain.Entities.WfxGDI>>
    {
        private readonly IWfxGDIRepository _repository;
        public GetWfxGDIQueryHandler(
            IWfxGDIRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.WfxGDI>> Handle(GetWfxGDIQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            return entity == null
                ? new($"WfxGDI Not Found (Id:{query.Id}).")
                : new Response<Domain.Entities.WfxGDI>(entity);
        }
    }
}
