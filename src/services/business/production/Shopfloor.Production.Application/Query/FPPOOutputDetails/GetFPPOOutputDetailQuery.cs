using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.FPPOOutputDetails
{
    public class GetFPPOOutputDetailQuery : IRequest<Response<FPPOOutputDetail>>
    {
        public int Id { get; set; }
    }
    public class GetFPPOOutputDetailQueryHandler : IRequestHandler<GetFPPOOutputDetailQuery, Response<FPPOOutputDetail>>
    {
        private readonly IFPPOOutputDetailRepository _repository;
        public GetFPPOOutputDetailQueryHandler(IFPPOOutputDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<FPPOOutputDetail>> Handle(GetFPPOOutputDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"FPPOOutputDetail Not Found (Id:{query.Id}).");
            return new Response<FPPOOutputDetail>(entity);
        }
    }
}
