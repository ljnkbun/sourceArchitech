using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRChemicalValues
{
    public class CreateDyeingTBRChemicalValueCommand : IRequest<Response<int>>
    {
        public int DyeingTBRChemicalId { get; set; }

        public int VersionIndex { get; set; }

        public decimal Value { get; set; }
    }

    public class CreateDyeingTBRChemicalValueCommandHandler : IRequestHandler<CreateDyeingTBRChemicalValueCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRChemicalValueRepository _repository;

        public CreateDyeingTBRChemicalValueCommandHandler(IMapper mapper,
            IDyeingTBRChemicalValueRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingTBRChemicalValueCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingTBRChemicalValue>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}