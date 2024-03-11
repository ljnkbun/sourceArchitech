using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.OneHundredPointSystemDetails
{
    public class UpdateOneHundredPointSystemDetailCommand : IRequest<Response<int>>
    {
        public decimal? FromKg { get; set; }
		public decimal? ToKg { get; set; }
		public int? FromDefect { get; set; }
		public int? ToDefect { get; set; }
		public OneHundredPointType Point { get; set; }
        public int Id { get; set; }
       
        public bool IsActive { set; get; }
    }
    public class UpdateOneHundredPointSystemDetailCommandHandler : IRequestHandler<UpdateOneHundredPointSystemDetailCommand, Response<int>>
    {
        private readonly IOneHundredPointSystemDetailRepository _repository;
        public UpdateOneHundredPointSystemDetailCommandHandler(IOneHundredPointSystemDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateOneHundredPointSystemDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"OneHundredPointSystemDetail Not Found.");
            entity.IsActive = command.IsActive;
            entity.FromKg = command.FromKg;
			entity.ToKg = command.ToKg;
			entity.FromDefect = command.FromDefect;
			entity.ToDefect = command.ToDefect;
			entity.Point = command.Point;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
