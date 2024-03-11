using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.QCDefinitionDefects
{
    public class UpdateQCDefinitionDefectCommand : IRequest<Response<int>>
    {
        public int QCDefinitionId { get; set; }
		public int QCDefectId { get; set; }
        public int Id { get; set; }
       
        public bool IsActive { set; get; }
    }
    public class UpdateQCDefinitionDefectCommandHandler : IRequestHandler<UpdateQCDefinitionDefectCommand, Response<int>>
    {
        private readonly IQCDefinitionDefectRepository _repository;
        public UpdateQCDefinitionDefectCommandHandler(IQCDefinitionDefectRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateQCDefinitionDefectCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new ($"QCDefinitionDefect Not Found.");
            entity.IsActive = command.IsActive;
            entity.QCDefinitionId = command.QCDefinitionId;
			entity.QCDefectId = command.QCDefectId;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
