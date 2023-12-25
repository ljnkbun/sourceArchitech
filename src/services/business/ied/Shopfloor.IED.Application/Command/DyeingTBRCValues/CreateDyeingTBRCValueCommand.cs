using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRCValues
{
    public class CreateDyeingTBRCValueCommand : IRequest<Response<int>>
    {
        public int DyeingTBRChemicalId { get; set; }

        public int DyeingTBRVersionId { get; set; }

        public decimal Value { get; set; }
    }

    public class CreateDyeingTBRCValueCommandHandler : IRequestHandler<CreateDyeingTBRCValueCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRCValueRepository _repository;

        public CreateDyeingTBRCValueCommandHandler(IMapper mapper,
            IDyeingTBRCValueRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingTBRCValueCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingTBRCValue>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}