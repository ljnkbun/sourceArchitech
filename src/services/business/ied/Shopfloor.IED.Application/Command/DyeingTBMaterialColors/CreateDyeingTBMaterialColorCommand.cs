using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBMaterialColors
{
    public class CreateDyeingTBMaterialColorCommand : IRequest<Response<int>>
    {
        public int DyeingTBMaterialId { get; set; }

        public string Color { get; set; }

        public string Pantone { get; set; }

        public TBMaterialColorStatus Status { get; set; }
    }

    public class CreateDyeingTBMaterialColorCommandHandler : IRequestHandler<CreateDyeingTBMaterialColorCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBMaterialColorRepository _repository;

        public CreateDyeingTBMaterialColorCommandHandler(IMapper mapper,
            IDyeingTBMaterialColorRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingTBMaterialColorCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingTBMaterialColor>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}