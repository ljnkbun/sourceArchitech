using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Lines
{
    public class CreateLineCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Worker { get; set; }
        public int? WFXLineId { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
    }
    public class CreateLineCommandHandler : IRequestHandler<CreateLineCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ILineRepository _repository;
        public CreateLineCommandHandler(IMapper mapper,
            ILineRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateLineCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Line>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
