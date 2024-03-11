using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Command.StripFactoryDetails;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactories
{
    public class UpdateStripFactoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int PlanningGroupFactoryId { get; set; }
        public int PORId { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainningQuantity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsPlanning { get; set; }
        public bool IsSplitBatch { get; set; }
        public bool IsAllocated { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateStripFactoryDetailCommand> StripFactoryDetails { get; set; }
    }
    public class UpdateStripFactoryCommandHandler : IRequestHandler<UpdateStripFactoryCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStripFactoryRepository _repository;
        public UpdateStripFactoryCommandHandler(IMapper mapper
            , IStripFactoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateStripFactoryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"StripFactory Not Found.");
            entity.PlanningGroupFactoryId = command.PlanningGroupFactoryId;
            entity.PORId = command.PORId;
            entity.Quantity = command.Quantity;
            entity.RemainningQuantity = command.RemainningQuantity;
            entity.StartDate = command.StartDate;
            entity.EndDate = command.EndDate;
            entity.IsPlanning = command.IsPlanning;
            entity.IsSplitBatch = command.IsSplitBatch;
            entity.IsAllocated = command.IsAllocated;
            entity.IsActive = command.IsActive;
            entity.StripFactoryDetails = _mapper.Map<ICollection<StripFactoryDetail>>(command.StripFactoryDetails);
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
