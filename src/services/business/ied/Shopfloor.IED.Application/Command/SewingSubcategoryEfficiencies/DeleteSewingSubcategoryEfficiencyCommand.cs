using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingSubcategoryEfficiencies
{
    public class DeleteSewingSubcategoryEfficiencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSewingSubcategoryEfficiencyCommandHandler : IRequestHandler<DeleteSewingSubcategoryEfficiencyCommand, Response<int>>
    {
        private readonly ISewingSubcategoryEfficiencyRepository _repository;

        public DeleteSewingSubcategoryEfficiencyCommandHandler(ISewingSubcategoryEfficiencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteSewingSubcategoryEfficiencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingSubcategoryEfficiency Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}