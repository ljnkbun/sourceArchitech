using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SpinningMethods
{
    public class DeleteSpinningMethodCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSpinningMethodCommandHandler : IRequestHandler<DeleteSpinningMethodCommand, Response<int>>
    {
        private readonly ISpinningMethodRepository _repository;
        public DeleteSpinningMethodCommandHandler(ISpinningMethodRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSpinningMethodCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SpinningMethod Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}

