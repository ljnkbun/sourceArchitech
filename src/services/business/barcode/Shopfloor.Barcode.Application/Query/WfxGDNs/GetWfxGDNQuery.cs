using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.WfxGDNs
{
    public class GetWfxGDNQuery : IRequest<Response<WfxGDN>>
    {
        public int Id { get; set; }
    }
    public class GetWfxGDNEntityQueryHandler : IRequestHandler<GetWfxGDNQuery, Response<WfxGDN>>
    {
        private readonly IWfxGDNRepository _repository;
        public GetWfxGDNEntityQueryHandler(
            IWfxGDNRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<WfxGDN>> Handle(GetWfxGDNQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            return entity == null
                ? new($"Recipe Unit Not Found (Id:{query.Id}).")
                : new Response<WfxGDN>(entity);
        }
    }
}
