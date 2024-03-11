using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRequestFiles
{
    public class GetDyeingTBRequestFileQuery : IRequest<Response<Domain.Entities.DyeingTBRequestFile>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingTBRequestFileQueryHandler : IRequestHandler<GetDyeingTBRequestFileQuery, Response<Domain.Entities.DyeingTBRequestFile>>
    {
        private readonly IDyeingTBRequestFileRepository _repository;

        public GetDyeingTBRequestFileQueryHandler(IDyeingTBRequestFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBRequestFile>> Handle(GetDyeingTBRequestFileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"DyeingTBRequestFile Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingTBRequestFile>(entity);
        }
    }
}