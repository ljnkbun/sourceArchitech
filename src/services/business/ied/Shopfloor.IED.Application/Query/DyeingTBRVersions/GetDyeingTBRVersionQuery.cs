using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRVersions
{
    public class GetDyeingTBRVersionQuery : IRequest<Response<Domain.Entities.DyeingTBRVersion>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingTBRVersionQueryHandler : IRequestHandler<GetDyeingTBRVersionQuery, Response<Domain.Entities.DyeingTBRVersion>>
    {
        private readonly IDyeingTBRVersionRepository _repository;

        public GetDyeingTBRVersionQueryHandler(IDyeingTBRVersionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBRVersion>> Handle(GetDyeingTBRVersionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"DyeingTBRVersion Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingTBRVersion>(entity);
        }
    }
}