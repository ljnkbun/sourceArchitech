using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingBundles
{
    public class DeleteSewingBundleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSewingBundleCommandHandler : IRequestHandler<DeleteSewingBundleCommand, Response<int>>
    {
        private readonly ISewingBundleRepository _repository;

        public DeleteSewingBundleCommandHandler(ISewingBundleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteSewingBundleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingBundle Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}