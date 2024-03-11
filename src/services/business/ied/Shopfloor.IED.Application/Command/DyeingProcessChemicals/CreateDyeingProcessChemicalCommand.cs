using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingProcessChemicals
{
    public class CreateDyeingProcessChemicalCommand : IRequest<Response<int>>
    {
        public int DyeingRoutingId { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string SubCategoryCode { get; set; }

        public string SubCategoryName { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }
    }

    public class CreateDyeingProcessChemicalCommandHandler : IRequestHandler<CreateDyeingProcessChemicalCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingProcessChemicalRepository _repository;

        public CreateDyeingProcessChemicalCommandHandler(IMapper mapper,
            IDyeingProcessChemicalRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingProcessChemicalCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingProcessChemical>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}