using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InpectionTCStandards
{
    public class DeleteInpectionTCStandardCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteInpectionTCStandardCommandHandler : IRequestHandler<DeleteInpectionTCStandardCommand, Response<int>>
    {
        private readonly IInpectionTCStandardRepository _repository;
        public DeleteInpectionTCStandardCommandHandler(IInpectionTCStandardRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteInpectionTCStandardCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"InpectionTCStandard Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
