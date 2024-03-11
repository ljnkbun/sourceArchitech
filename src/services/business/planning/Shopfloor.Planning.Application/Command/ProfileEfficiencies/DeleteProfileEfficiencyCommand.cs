using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.ProfileEfficiencies
{
    public class DeleteProfileEfficiencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProfileEfficiencyCommandHandler : IRequestHandler<DeleteProfileEfficiencyCommand, Response<int>>
    {
        private readonly IProfileEfficiencyRepository _repository;
        public DeleteProfileEfficiencyCommandHandler(IProfileEfficiencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProfileEfficiencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"ProfileEfficiency Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
