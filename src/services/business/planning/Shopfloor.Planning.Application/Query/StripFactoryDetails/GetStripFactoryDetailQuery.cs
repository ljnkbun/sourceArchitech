using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.StripFactoryDetails
{
    public class GetStripFactoryDetailQuery : IRequest<Response<StripFactoryDetail>>
    {
        public int Id { get; set; }
    }

    public class GetStripFactoryDetailQueryHandler : IRequestHandler<GetStripFactoryDetailQuery, Response<StripFactoryDetail>>
    {
        private readonly IStripFactoryDetailRepository _repository;

        public GetStripFactoryDetailQueryHandler(IStripFactoryDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<StripFactoryDetail>> Handle(GetStripFactoryDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"StripFactoryDetail Not Found (Id:{query.Id}).");
            return new Response<StripFactoryDetail>(entity);
        }
    }
}
