using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SpinningProcesses
{
    public class CreateSpinningProcessCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateSpinningProcessCommandHandler : IRequestHandler<CreateSpinningProcessCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISpinningProcessRepository _repository;
        public CreateSpinningProcessCommandHandler(IMapper mapper,
            ISpinningProcessRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSpinningProcessCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SpinningProcess>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
