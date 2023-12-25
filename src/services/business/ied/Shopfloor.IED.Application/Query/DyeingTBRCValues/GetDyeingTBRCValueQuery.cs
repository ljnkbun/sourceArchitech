using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRCValues
{
    public class GetDyeingTBRCValueQuery : IRequest<Response<Domain.Entities.DyeingTBRCValue>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingTBRCValueQueryHandler : IRequestHandler<GetDyeingTBRCValueQuery, Response<Domain.Entities.DyeingTBRCValue>>
    {
        private readonly IDyeingTBRCValueRepository _repository;

        public GetDyeingTBRCValueQueryHandler(IDyeingTBRCValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBRCValue>> Handle(GetDyeingTBRCValueQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"DyeingTBRCValue Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingTBRCValue>(entity);
        }
    }
}