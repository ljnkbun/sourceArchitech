using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.UOMs
{
    public class GetUOMQuery : IRequest<Response<UOM>>
    {
        public int Id { get; set; }
    }

    public class GetUOMQueryHandler : IRequestHandler<GetUOMQuery, Response<UOM>>
    {
        private readonly IUOMRepository _repository;

        public GetUOMQueryHandler(IUOMRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<UOM>> Handle(GetUOMQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) return new($"UOM Not Found (Id:{query.Id}).");
            return new Response<UOM>(entity);
        }
    }
}