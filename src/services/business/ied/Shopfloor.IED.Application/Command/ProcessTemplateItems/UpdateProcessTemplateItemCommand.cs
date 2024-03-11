using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.ProcessTemplateItems
{
    public class UpdateProcessTemplateItemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int ProcessTemplateId { get; set; }
        public int Division { get; set; }
        public int Priority { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateProcessTemplateItemCommandHandler : IRequestHandler<UpdateProcessTemplateItemCommand, Response<int>>
    {
        private readonly IProcessTemplateItemRepository _repository;
        public UpdateProcessTemplateItemCommandHandler(IProcessTemplateItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateProcessTemplateItemCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"ProcessTemplateItem Not Found.");

            entity.ProcessTemplateId = command.ProcessTemplateId;
            entity.Division = command.Division;
            entity.Priority = command.Priority;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
