using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingRoutings
{
    public class GetDyeingRoutingQuery : IRequest<Response<Domain.Entities.DyeingRouting>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingRoutingQueryHandler : IRequestHandler<GetDyeingRoutingQuery, Response<Domain.Entities.DyeingRouting>>
    {
        private readonly IDyeingRoutingRepository _repository;

        public GetDyeingRoutingQueryHandler(IDyeingRoutingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingRouting>> Handle(GetDyeingRoutingQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) return new($"DyeingRouting Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingRouting>(entity);
        }
    }
}