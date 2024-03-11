using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRChemicals
{
    public class GetDyeingTBRChemicalQuery : IRequest<Response<Domain.Entities.DyeingTBRChemical>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingTBRChemicalQueryHandler : IRequestHandler<GetDyeingTBRChemicalQuery, Response<Domain.Entities.DyeingTBRChemical>>
    {
        private readonly IDyeingTBRChemicalRepository _repository;

        public GetDyeingTBRChemicalQueryHandler(IDyeingTBRChemicalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBRChemical>> Handle(GetDyeingTBRChemicalQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"DyeingTBRChemical Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingTBRChemical>(entity);
        }
    }
}