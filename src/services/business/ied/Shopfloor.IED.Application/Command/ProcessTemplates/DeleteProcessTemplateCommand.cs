using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.ProcessTemplates
{
    public class DeleteProcessTemplateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProcessTemplateCommandHandler : IRequestHandler<DeleteProcessTemplateCommand, Response<int>>
    {
        private readonly IProcessTemplateRepository _repository;
        public DeleteProcessTemplateCommandHandler(IProcessTemplateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProcessTemplateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"ProcessTemplate Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
