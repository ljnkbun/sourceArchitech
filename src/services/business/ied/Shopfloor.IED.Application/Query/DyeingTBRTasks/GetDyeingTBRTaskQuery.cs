using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRTasks
{
    public class GetDyeingTBRTaskQuery : IRequest<Response<Domain.Entities.DyeingTBRTask>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingTBRTaskQueryHandler : IRequestHandler<GetDyeingTBRTaskQuery, Response<Domain.Entities.DyeingTBRTask>>
    {
        private readonly IDyeingTBRTaskRepository _repository;

        public GetDyeingTBRTaskQueryHandler(IDyeingTBRTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBRTask>> Handle(GetDyeingTBRTaskQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) return new($"DyeingTBRTask Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingTBRTask>(entity);
        }
    }
}