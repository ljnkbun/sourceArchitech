using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.RequestArticleOutputs;
using Shopfloor.IED.Application.Command.RequestDivisions;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestDivisionProcesses
{
    public class CreateRequestDivisionProcessCommand : IRequest<Response<int>>
    {
        public int RequestDivisionId { get; set; }
        public int ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public int LineNumber { get; set; }
        public Status Status { get; set; }
        public ICollection<CreateRequestArticleOutputCommand> RequestArticleOutputs { get; set; }
    }
    public class CreateRequestDivisionProcessCommandHandler : IRequestHandler<CreateRequestDivisionProcessCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestDivisionProcessRepository _repository;
        public CreateRequestDivisionProcessCommandHandler(IMapper mapper,
            IRequestDivisionProcessRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRequestDivisionProcessCommand RequestDivisionProcess, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RequestDivisionProcess>(RequestDivisionProcess);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
