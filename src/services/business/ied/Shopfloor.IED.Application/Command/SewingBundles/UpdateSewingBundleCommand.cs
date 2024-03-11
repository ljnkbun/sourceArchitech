using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingBundles
{
    public class UpdateSewingBundleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateSewingBundleCommandHandler : IRequestHandler<UpdateSewingBundleCommand, Response<int>>
    {
        private readonly ISewingBundleRepository _repository;
        private readonly ISewingTaskLibRepository _taskRepository;

        public UpdateSewingBundleCommandHandler(ISewingBundleRepository repository, ISewingTaskLibRepository taskRepository)
        {
            _repository = repository;
            _taskRepository = taskRepository;
        }

        public async Task<Response<int>> Handle(UpdateSewingBundleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingBundle Not Found.");

            if(IsUpdateQuanlityOfBundleBeingUsedAsync(entity.Quantity, command)) 
                return new($"Update Quanlity is denied. This Bundle is being used.");

            entity.Name = command.Name;
            entity.Code = command.Code;
            entity.Quantity = command.Quantity;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
        private bool IsUpdateQuanlityOfBundleBeingUsedAsync(decimal currentQuality, UpdateSewingBundleCommand command)
        {
            if (command.Quantity != currentQuality)
            {
                var task = _taskRepository.GetBySewingBundleIdAsync(command.Id).Result;
                if (task != null) return true;
            }
            return false;
        }
    }
}