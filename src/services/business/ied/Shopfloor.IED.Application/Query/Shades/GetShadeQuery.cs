using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Shades
{
    public class GetShadeQuery : IRequest<Response<Shade>>
    {
        public int Id { get; set; }
    }
    public class GetShadeQueryHandler : IRequestHandler<GetShadeQuery, Response<Shade>>
    {
        private readonly IShadeRepository _repository;
        public GetShadeQueryHandler(IShadeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Shade>> Handle(GetShadeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Shade Not Found (Id:{query.Id}).");
            return new Response<Shade>(entity);
        }
    }
}
