using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Ports
{
    public class CreatePortCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool PortOfLoading { get; set; }
        public bool PortOfDischarge { get; set; }
        public bool PortOfReceiptByPreCarrier { get; set; }
        public int CountryId { get; set; }
    }
    public class CreatePortCommandHandler : IRequestHandler<CreatePortCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPortRepository _repository;
        public CreatePortCommandHandler(IMapper mapper,
            IPortRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePortCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Port>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
