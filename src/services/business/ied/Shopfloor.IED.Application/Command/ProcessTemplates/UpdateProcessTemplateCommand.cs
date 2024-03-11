using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.ProcessTemplates
{
    public class UpdateProcessTemplateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateProcessTemplateCommandHandler : IRequestHandler<UpdateProcessTemplateCommand, Response<int>>
    {
        private readonly IProcessTemplateRepository _repository;
        public UpdateProcessTemplateCommandHandler(IProcessTemplateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateProcessTemplateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"ProcessTemplate Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
