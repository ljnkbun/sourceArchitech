using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingRoutings
{
    public class CreateKnittingRoutingCommand : IRequest<Response<int>>
    {
        public int KnittingIEDId { get; set; }
        public int LineNumber { get; set; }
        public string KnittingProcess { get; set; }
        public string KnittingProcessCode { get; set; }
        public string KnittingOperation { get; set; }
        public string KnittingOperationCode { get; set; }
        public int MachineTypeId { get; set; }
        public string MachineTypeName { get; set; }
    }
    public class CreateKnittingRoutingCommandHandler : IRequestHandler<CreateKnittingRoutingCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingRoutingRepository _repository;
        public CreateKnittingRoutingCommandHandler(IMapper mapper,
            IKnittingRoutingRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateKnittingRoutingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<KnittingRouting>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
