using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingSubcategoryEfficiencies
{
    public class UpdateSewingSubcategoryEfficiencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int SewingEfficiencyProfileId { get; set; }
        public string SubCategory { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateSewingSubcategoryEfficiencyCommandHandler : IRequestHandler<UpdateSewingSubcategoryEfficiencyCommand, Response<int>>
    {
        private readonly ISewingSubcategoryEfficiencyRepository _repository;

        public UpdateSewingSubcategoryEfficiencyCommandHandler(ISewingSubcategoryEfficiencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateSewingSubcategoryEfficiencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"SewingSubcategoryEfficiency Not Found.");

            entity.SewingEfficiencyProfileId = command.SewingEfficiencyProfileId;
            entity.SubCategory = command.SubCategory;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}