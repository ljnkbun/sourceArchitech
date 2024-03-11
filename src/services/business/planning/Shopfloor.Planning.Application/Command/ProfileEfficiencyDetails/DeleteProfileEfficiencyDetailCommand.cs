using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.ProfileEfficiencyDetails
{
    public class DeleteProfileEfficiencyDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProfileEfficiencyDetailCommandHandler : IRequestHandler<DeleteProfileEfficiencyDetailCommand, Response<int>>
    {
        private readonly IProfileEfficiencyDetailRepository _repository;
        public DeleteProfileEfficiencyDetailCommandHandler(IProfileEfficiencyDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProfileEfficiencyDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"ProfileEfficiencyDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
