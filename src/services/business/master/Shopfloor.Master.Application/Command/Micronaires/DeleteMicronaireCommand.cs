using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Micronaires
{
    public class DeleteMicronaireCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteMicronaireCommandHandler : IRequestHandler<DeleteMicronaireCommand, Response<int>>
    {
        private readonly IMicronaireRepository _repository;
        public DeleteMicronaireCommandHandler(IMicronaireRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteMicronaireCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Micronaire Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
