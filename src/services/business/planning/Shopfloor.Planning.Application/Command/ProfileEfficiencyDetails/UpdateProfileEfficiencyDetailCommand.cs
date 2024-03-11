using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Message;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.ProfileEfficiencyDetails
{
    public class UpdateProfileEfficiencyDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int ProfileEfficiencyId { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public decimal EfficiencyValue { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateProfileEfficiencyDetailCommandHandler : IRequestHandler<UpdateProfileEfficiencyDetailCommand, Response<int>>
    {
        private readonly IProfileEfficiencyDetailRepository _repository;
        private readonly MassTransit.IPublishEndpoint _publishEndpoint;
        private readonly JobSettings _settings;

        public UpdateProfileEfficiencyDetailCommandHandler(IProfileEfficiencyDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateProfileEfficiencyDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"ProfileEfficiencyDetail Not Found.");
            var oldEfficiencyValue = entity.EfficiencyValue;

            entity.ProfileEfficiencyId = command.ProfileEfficiencyId;
            entity.SubCategoryId = command.SubCategoryId;
            entity.SubCategoryCode = command.SubCategoryCode;
            entity.SubCategoryName = command.SubCategoryName;
            entity.EfficiencyValue = command.EfficiencyValue;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);

            if (command.EfficiencyValue != oldEfficiencyValue)
            {
                //Call calculate factory capacity
                await CallFactoryCapacity(cancellationToken);
            }

            return new Response<int>(entity.Id);
        }

        private async Task CallFactoryCapacity(CancellationToken cancellationToken)
        {
            var fDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var tDate = fDate.AddMonths(_settings.FactoryCapacity.Month);
            await _publishEndpoint.Publish(new CalculateFactoryCapacityMessage()
            {
                FromDate = fDate,
                ToDate = tDate
            }, cancellationToken);
        }
    }
}
