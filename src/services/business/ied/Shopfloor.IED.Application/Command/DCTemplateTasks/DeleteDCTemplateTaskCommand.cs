using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DCTemplateTasks
{
    public class DeleteDCTemplateTaskCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDCTemplateTaskCommandHandler : IRequestHandler<DeleteDCTemplateTaskCommand, Response<int>>
    {
        private readonly IDCTemplateTaskRepository _repository;

        public DeleteDCTemplateTaskCommandHandler(IDCTemplateTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDCTemplateTaskCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(command.Id);
            if (entity == null) return new($"DCTemplateTask Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}