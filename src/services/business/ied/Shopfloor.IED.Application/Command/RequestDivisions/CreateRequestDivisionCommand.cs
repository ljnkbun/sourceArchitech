using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.RequestDivisionProcesses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestDivisions
{
    public class CreateRequestDivisionCommand : IRequest<Response<int>>
    {
        public int RequestId { get; set; }
        public int DivisionId { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public int LineNumber { get; set; }
        public Status Status { get; set; }
        public ICollection<CreateRequestDivisionProcessCommand> RequestDivisionProcesses { get; set; }
    }
    public class CreateRequestDivisionCommandHandler : IRequestHandler<CreateRequestDivisionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestDivisionRepository _repository;
        public CreateRequestDivisionCommandHandler(IMapper mapper,
            IRequestDivisionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRequestDivisionCommand RequestDivision, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RequestDivision>(RequestDivision);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
