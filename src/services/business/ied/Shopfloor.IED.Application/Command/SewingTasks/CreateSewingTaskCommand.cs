using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingTasks
{
    public class CreateSewingTaskCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public string Freq { get; set; }
        public decimal TotalTMU { get; set; }
    }
    public class CreateSewingTaskCommandHandler : IRequestHandler<CreateSewingTaskCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingTaskRepository _repository;
        public CreateSewingTaskCommandHandler(IMapper mapper,
            ISewingTaskRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingTask>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
