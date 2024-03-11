using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Strengths
{
    public class DeleteStrengthCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteStrengthCommandHandler : IRequestHandler<DeleteStrengthCommand, Response<int>>
    {
        private readonly IStrengthRepository _repository;
        public DeleteStrengthCommandHandler(IStrengthRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteStrengthCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Strength Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
