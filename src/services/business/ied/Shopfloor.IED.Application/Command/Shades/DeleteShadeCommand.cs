using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Shades
{
    public class DeleteShadeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteShadeCommandHandler : IRequestHandler<DeleteShadeCommand, Response<int>>
    {
        private readonly IShadeRepository _repository;
        public DeleteShadeCommandHandler(IShadeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteShadeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Shape Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
