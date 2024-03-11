using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Concentrates
{
    public class DeleteConcentrateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteConcentrateCommandHandler : IRequestHandler<DeleteConcentrateCommand, Response<int>>
    {
        private readonly IConcentrateRepository _repository;
        public DeleteConcentrateCommandHandler(IConcentrateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteConcentrateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Concentrate Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
