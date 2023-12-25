using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestDivisions
{
    public class DeleteRequestDivisionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteRequestDivisionCommandHandler : IRequestHandler<DeleteRequestDivisionCommand, Response<int>>
    {
        private readonly IRequestDivisionRepository _repository;
        public DeleteRequestDivisionCommandHandler(IRequestDivisionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteRequestDivisionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"RequestDivision Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
