using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingBorderStyles
{
    public class DeleteWeavingBorderStyleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteWeavingBorderStyleCommandHandler : IRequestHandler<DeleteWeavingBorderStyleCommand, Response<int>>
    {
        private readonly IWeavingBorderStyleRepository _repository;
        public DeleteWeavingBorderStyleCommandHandler(IWeavingBorderStyleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteWeavingBorderStyleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Shape Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
