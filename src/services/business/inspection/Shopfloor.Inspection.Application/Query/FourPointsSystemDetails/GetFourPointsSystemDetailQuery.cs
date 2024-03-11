using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.FourPointsSystemDetails
{
    public class GetFourPointsSystemDetailQuery : IRequest<Response<FourPointsSystemDetail>>
    {
        public int Id { get; set; }
    }
    public class GetFourPointsSystemDetailQueryHandler : IRequestHandler<GetFourPointsSystemDetailQuery, Response<FourPointsSystemDetail>>
    {
        private readonly IFourPointsSystemDetailRepository _repository;
        public GetFourPointsSystemDetailQueryHandler(IFourPointsSystemDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<FourPointsSystemDetail>> Handle(GetFourPointsSystemDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"FourPointsSystemDetails Not Found (Id:{query.Id}).");
            return new Response<FourPointsSystemDetail>(entity);
        }
    }
}
