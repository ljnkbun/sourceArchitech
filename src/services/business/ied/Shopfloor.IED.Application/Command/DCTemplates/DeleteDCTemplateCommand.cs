using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DCTemplates
{
    public class DeleteDCTemplateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDCTemplateCommandHandler : IRequestHandler<DeleteDCTemplateCommand, Response<int>>
    {
        private readonly IDCTemplateRepository _repository;

        public DeleteDCTemplateCommandHandler(IDCTemplateRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDCTemplateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"DCTemplate Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}