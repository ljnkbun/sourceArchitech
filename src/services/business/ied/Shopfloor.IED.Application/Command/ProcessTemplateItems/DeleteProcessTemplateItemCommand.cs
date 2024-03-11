using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.ProcessTemplateItems
{
    public class DeleteProcessTemplateItemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProcessTemplateItemCommandHandler : IRequestHandler<DeleteProcessTemplateItemCommand, Response<int>>
    {
        private readonly IProcessTemplateItemRepository _repository;
        public DeleteProcessTemplateItemCommandHandler(IProcessTemplateItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProcessTemplateItemCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"ProcessTemplateItem Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
