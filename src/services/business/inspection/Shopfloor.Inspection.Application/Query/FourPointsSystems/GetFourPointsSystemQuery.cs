using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.FourPointsSystems
{
    public class GetFourPointsSystemQuery : IRequest<Response<FourPointsSystem>>
    {
        public int Id { get; set; }
    }
    public class GetFourPointsSystemQueryHandler : IRequestHandler<GetFourPointsSystemQuery, Response<FourPointsSystem>>
    {
        private readonly IFourPointsSystemRepository _repository;
        public GetFourPointsSystemQueryHandler(IFourPointsSystemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<FourPointsSystem>> Handle(GetFourPointsSystemQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"FourPointsSystems Not Found (Id:{query.Id}).");
            return new Response<FourPointsSystem>(entity);
        }
    }
}
