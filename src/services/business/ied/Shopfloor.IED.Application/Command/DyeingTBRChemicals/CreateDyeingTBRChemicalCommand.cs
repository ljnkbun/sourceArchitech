using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRChemicals
{
    public class CreateDyeingTBRChemicalCommand : IRequest<Response<int>>
    {
        public int DyeingTBRTaskId { get; set; }
        public int ChemicalId { get; set; }
        public string ChemicalCode { get; set; }
        public string ChemicalName { get; set; }
        public string Unit { get; set; }
    }

    public class CreateDyeingTBRChemicalCommandHandler : IRequestHandler<CreateDyeingTBRChemicalCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRChemicalRepository _repository;

        public CreateDyeingTBRChemicalCommandHandler(IMapper mapper,
            IDyeingTBRChemicalRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingTBRChemicalCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingTBRChemical>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}