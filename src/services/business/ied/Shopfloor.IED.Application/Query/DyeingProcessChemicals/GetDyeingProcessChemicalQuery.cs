using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingProcessChemicals
{
    public class GetDyeingProcessChemicalQuery : IRequest<Response<Domain.Entities.DyeingProcessChemical>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingProcessChemicalQueryHandler : IRequestHandler<GetDyeingProcessChemicalQuery, Response<Domain.Entities.DyeingProcessChemical>>
    {
        private readonly IDyeingProcessChemicalRepository _repository;

        public GetDyeingProcessChemicalQueryHandler(IDyeingProcessChemicalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingProcessChemical>> Handle(GetDyeingProcessChemicalQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"DyeingProcessChemical Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingProcessChemical>(entity);
        }
    }
}