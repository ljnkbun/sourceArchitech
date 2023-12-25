using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DCTemplateDetails
{
    public class DeleteDCTemplateDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDCTemplateDetailCommandHandler : IRequestHandler<DeleteDCTemplateDetailCommand, Response<int>>
    {
        private readonly IDCTemplateDetailRepository _repository;

        public DeleteDCTemplateDetailCommandHandler(IDCTemplateDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDCTemplateDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"DCTemplateDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}