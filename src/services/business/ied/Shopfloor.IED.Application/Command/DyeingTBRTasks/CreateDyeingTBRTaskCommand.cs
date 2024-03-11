using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingTBRChemicals;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRTasks
{
    public class CreateDyeingTBRTaskCommand : IRequest<Response<int>>
    {
        public int LineNumber { get; set; }
        public int DyeingTBRecipeId { get; set; }
        public int DyeingProcessId { get; set; }
        public string DyeingProcessName { get; set; }
        public int DyeingOperationId { get; set; }
        public string DyeingOperationName { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public decimal Temperature { get; set; }
        public int Minute { get; set; }
        public decimal Ratio { get; set; }
        public ICollection<CreateDyeingTBRChemicalCommand> DyeingTBRChemicals { get; set; }
    }

    public class CreateDyeingTBRTaskCommandHandler : IRequestHandler<CreateDyeingTBRTaskCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRTaskRepository _repository;

        public CreateDyeingTBRTaskCommandHandler(IMapper mapper,
            IDyeingTBRTaskRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingTBRTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingTBRTask>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}