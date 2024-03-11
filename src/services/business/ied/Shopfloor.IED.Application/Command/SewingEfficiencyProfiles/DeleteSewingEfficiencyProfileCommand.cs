using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingEfficiencyProfiles
{
    public class DeleteSewingEfficiencyProfileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSewingEfficiencyProfileCommandHandler : IRequestHandler<DeleteSewingEfficiencyProfileCommand, Response<int>>
    {
        private readonly ISewingEfficiencyProfileRepository _repository;

        public DeleteSewingEfficiencyProfileCommandHandler(ISewingEfficiencyProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteSewingEfficiencyProfileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingEfficiencyProfile Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}