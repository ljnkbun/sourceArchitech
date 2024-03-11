using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.FourPointsSystemDetails
{
    public class UpdateFourPointsSystemDetailCommand : IRequest<Response<int>>
    {
        public decimal? From { get; set; }
		public decimal? To { get; set; }
		public GradeType GradeType { get; set; }
        public int Id { get; set; }
       
        public bool IsActive { set; get; }
    }
    public class UpdateFourPointsSystemDetailCommandHandler : IRequestHandler<UpdateFourPointsSystemDetailCommand, Response<int>>
    {
        private readonly IFourPointsSystemDetailRepository _repository;
        public UpdateFourPointsSystemDetailCommandHandler(IFourPointsSystemDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFourPointsSystemDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"FourPointsSystemDetail Not Found.");
            entity.IsActive = command.IsActive;
            entity.From = command.From;
			entity.To = command.To;
			entity.GradeType = command.GradeType;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
