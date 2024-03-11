using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRChemicalValues
{
    public class GetDyeingTBRChemicalValueQuery : IRequest<Response<Domain.Entities.DyeingTBRChemicalValue>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingTBRChemicalValueQueryHandler : IRequestHandler<GetDyeingTBRChemicalValueQuery, Response<Domain.Entities.DyeingTBRChemicalValue>>
    {
        private readonly IDyeingTBRChemicalValueRepository _repository;

        public GetDyeingTBRChemicalValueQueryHandler(IDyeingTBRChemicalValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DyeingTBRChemicalValue>> Handle(GetDyeingTBRChemicalValueQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"DyeingTBRChemicalValue Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DyeingTBRChemicalValue>(entity);
        }
    }
}