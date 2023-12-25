using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.ProcessTasks
{
    public class CreateProcessTaskCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
    public class CreateProcessTaskCommandHandler : IRequestHandler<CreateProcessTaskCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProcessTaskRepository _repository;
        public CreateProcessTaskCommandHandler(IMapper mapper,
            IProcessTaskRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProcessTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProcessTask>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
