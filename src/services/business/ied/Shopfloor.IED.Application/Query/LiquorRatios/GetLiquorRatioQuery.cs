using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.LiquorRatios
{
    public class GetLiquorRatioQuery : IRequest<Response<LiquorRatio>>
    {
        public int Id { get; set; }
    }
    public class GetLiquorRatioQueryHandler : IRequestHandler<GetLiquorRatioQuery, Response<LiquorRatio>>
    {
        private readonly ILiquorRatioRepository _repository;
        public GetLiquorRatioQueryHandler(ILiquorRatioRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<LiquorRatio>> Handle(GetLiquorRatioQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"LiquorRatio Not Found (Id:{query.Id}).");
            return new Response<LiquorRatio>(entity);
        }
    }
}
