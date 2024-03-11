using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.BuyerFiles
{
    public class GetBuyerFileQuery : IRequest<Response<Domain.Entities.BuyerFile>>
    {
        public int Id { get; set; }
    }

    public class GetBuyerFileQueryHandler : IRequestHandler<GetBuyerFileQuery, Response<Domain.Entities.BuyerFile>>
    {
        private readonly IBuyerFileRepository _repository;

        public GetBuyerFileQueryHandler(IBuyerFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.BuyerFile>> Handle(GetBuyerFileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"BuyerFile Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.BuyerFile>(entity);
        }
    }
}