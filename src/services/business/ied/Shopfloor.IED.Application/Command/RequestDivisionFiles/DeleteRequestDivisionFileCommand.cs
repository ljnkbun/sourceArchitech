using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestDivisionFiles
{
    public class DeleteRequestDivisionFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteRequestDivisionFileCommandHandler : IRequestHandler<DeleteRequestDivisionFileCommand, Response<int>>
    {
        private readonly IRequestDivisionFileRepository _repository;
        public DeleteRequestDivisionFileCommandHandler(IRequestDivisionFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteRequestDivisionFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"RequestDivisionFile Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
