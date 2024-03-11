using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionBySizes
{
    public class UpdateInspectionBySizeCommand : IRequest<Response<int>>
    {
       
		public decimal GRNQty { get; set; }
		public decimal PreInspectedQty { get; set; }
		public decimal LotQty { get; set; }
		public decimal InspectionQty { get; set; }
		public decimal ActualQty { get; set; }
		public int NoOfDefect { get; set; }
		public decimal OKQty { get; set; }
		public decimal BGroupQty { get; set; }
		public decimal BGroupUsable { get; set; }
		public decimal RejectedQty { get; set; }
		public decimal ExcessShortageQty { get; set; }
		public string ReasonforBGroup { get; set; }
        public int Id { get; set; }
        public bool IsActive { set; get; }
        public int InspectionId { get; set; }
    }
    public class UpdateInspectionBySizeCommandHandler : IRequestHandler<UpdateInspectionBySizeCommand, Response<int>>
    {
        private readonly IInspectionBySizeRepository _repository;
        public UpdateInspectionBySizeCommandHandler(IInspectionBySizeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateInspectionBySizeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"InspectionBySize Not Found.");
            entity.IsActive = command.IsActive;
			entity.GRNQty = command.GRNQty;
			entity.PreInspectedQty = command.PreInspectedQty;
			entity.LotQty = command.LotQty;
			entity.InspectionQty = command.InspectionQty;
			entity.ActualQty = command.ActualQty;
			entity.NoOfDefect = command.NoOfDefect;
			entity.OKQty = command.OKQty;
			entity.BGroupQty = command.BGroupQty;
			entity.BGroupUsable = command.BGroupUsable;
			entity.RejectedQty = command.RejectedQty;
			entity.ExcessShortageQty = command.ExcessShortageQty;
			entity.ReasonforBGroup = command.ReasonforBGroup;
			entity.InspectionId = command.InspectionId;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
