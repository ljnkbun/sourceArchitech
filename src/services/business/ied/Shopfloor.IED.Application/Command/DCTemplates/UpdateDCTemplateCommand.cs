using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DCTemplate
{
    public class UpdateDCTemplateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateDCTemplateCommandHandler : IRequestHandler<UpdateDCTemplateCommand, Response<int>>
    {
        private readonly IDCTemplateRepository _repository;

        public UpdateDCTemplateCommandHandler(IDCTemplateRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDCTemplateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DCTemplate Not Found.");

            entity.Name = command.Name;
            entity.Code = command.Code;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}