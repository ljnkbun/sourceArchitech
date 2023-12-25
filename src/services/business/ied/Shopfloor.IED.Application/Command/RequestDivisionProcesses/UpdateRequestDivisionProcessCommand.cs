using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestDivisionProcesses
{
    public class UpdateRequestDivisionProcessCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public int LineNumber { get; set; }
        public Status Status { get; set; }
    }
    public class UpdateRequestDivisionProcessCommandHandler : IRequestHandler<UpdateRequestDivisionProcessCommand, Response<int>>
    {
        private readonly IRequestDivisionProcessRepository _repository;
        public UpdateRequestDivisionProcessCommandHandler(IRequestDivisionProcessRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateRequestDivisionProcessCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"RequestDivisionProcess Not Found.");

            entity.ProcessId = command.ProcessId;
            entity.ProcessCode = command.ProcessCode;
            entity.ProcessName = command.ProcessName;
            entity.LineNumber = command.LineNumber;
            entity.Status = command.Status;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
