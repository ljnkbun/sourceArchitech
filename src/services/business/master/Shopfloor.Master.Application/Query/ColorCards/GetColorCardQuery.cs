using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.ColorCards
{
    public class GetColorCardQuery : IRequest<Response<ColorCard>>
    {
        public int Id { get; set; }
    }
    public class GetColorCardQueryHandler : IRequestHandler<GetColorCardQuery, Response<ColorCard>>
    {
        private readonly IColorCardRepository _repository;
        public GetColorCardQueryHandler(IColorCardRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ColorCard>> Handle(GetColorCardQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"ColorCard Not Found (Id: {query.Id}).");
            return new Response<ColorCard>(entity);
        }
    }
}
