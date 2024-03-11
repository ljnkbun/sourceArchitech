using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingProcessChemicals;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingRoutings
{
    public class CreateDyeingRoutingCommand : IRequest<Response<int>>
    {
        public int DyeingIEDId { get; set; }

        public int LineNumber { get; set; }

        public string DyeingProcess { get; set; }

        public string DyeingProcessCode { get; set; }

        public string DyeingOperationCode { get; set; }

        public string DyeingOperation { get; set; }

        public string MachineCode { get; set; }

        public string MachineName { get; set; }

        public decimal Efficiency { get; set; }

        public decimal MachineTime { get; set; }

        public decimal Temperature { get; set; }

        public decimal OperationTime { get; set; }
    }

    public class CreateDyeingRoutingCommandHandler : IRequestHandler<CreateDyeingRoutingCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingRoutingRepository _repository;

        public CreateDyeingRoutingCommandHandler(IMapper mapper,
            IDyeingRoutingRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingRoutingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingRouting>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}