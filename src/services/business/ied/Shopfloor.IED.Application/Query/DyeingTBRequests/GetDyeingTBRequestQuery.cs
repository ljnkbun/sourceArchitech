using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRequests
{
    public class GetDyeingTBRequestQuery : IRequest<Response<Domain.Entities.DyeingTBRequest>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingTBRequestQueryHandler : IRequestHandler<GetDyeingTBRequestQuery, Response<Domain.Entities.DyeingTBRequest>>
    {
        private readonly IDyeingTBRequestRepository _repository;

        public GetDyeingTBRequestQueryHandler(IDyeingTBRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBRequest>> Handle(GetDyeingTBRequestQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"DyeingTBRequest Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingTBRequest>(entity);
        }
    }
}