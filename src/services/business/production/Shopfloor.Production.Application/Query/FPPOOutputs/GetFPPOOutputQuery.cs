using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.FPPOOutputs
{
    public class GetFPPOOutputQuery : IRequest<Response<FPPOOutput>>
    {
        public int Id { get; set; }
    }
    public class GetFPPOOutputQueryHandler : IRequestHandler<GetFPPOOutputQuery, Response<FPPOOutput>>
    {
        private readonly IFPPOOutputRepository _repository;
        public GetFPPOOutputQueryHandler(IFPPOOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<FPPOOutput>> Handle(GetFPPOOutputQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetDeepByIdAsync(query.Id);
            if (entity == null) return new($"FPPOOutput Not Found (Id:{query.Id}).");
            return new Response<FPPOOutput>(entity);
        }
    }
}
