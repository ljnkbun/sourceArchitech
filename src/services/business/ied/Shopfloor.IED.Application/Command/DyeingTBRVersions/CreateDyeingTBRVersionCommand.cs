using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingTBRChemicals;
using Shopfloor.IED.Application.Command.DyeingTBRCValues;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRVersions
{
    public class CreateDyeingTBRVersionCommand : IRequest<Response<int>>
    {
        public int DyeingTBRecipeId { get; set; }

        public int Version { get; set; }

        public DateTime DoTime { get; set; }

        public bool Approved { get; set; }

        public virtual ICollection<CreateDyeingTBRCValueCommand> DyeingTBRCValues { get; set; }
    }

    public class CreateDyeingTBRVersionCommandHandler : IRequestHandler<CreateDyeingTBRVersionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRVersionRepository _repository;

        public CreateDyeingTBRVersionCommandHandler(IMapper mapper,
            IDyeingTBRVersionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingTBRVersionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingTBRVersion>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}