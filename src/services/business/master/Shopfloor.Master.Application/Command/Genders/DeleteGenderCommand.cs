using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Genders
{
    public class DeleteGenderCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderCommand, Response<int>>
    {
        private readonly IGenderRepository _repository;
        public DeleteGenderCommandHandler(IGenderRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteGenderCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Gender Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
