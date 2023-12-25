using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRecipes
{
    public class UpdateDyeingTBRecipeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingTBMaterialColorId { get; set; }

        public int TemplateId { get; set; }

        public string TemplateName { get; set; }

        public string TCFNo { get; set; }

        public int ApproveVersionId { get; set; }

        public DateTime ApproveDate { get; set; }

        public string Comment { get; set; }

        public string Buyer { get; set; }

        public string BuyerRef { get; set; }

        public string GarmentStyleRef { get; set; }

        public DateTime ExpectedDate { get; set; }

        public string Color { get; set; }

        public string Concentration { get; set; }

        public int VersionQty { get; set; }

        public TBRecipeStatus Status { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateDyeingTBRecipeCommandHandler : IRequestHandler<UpdateDyeingTBRecipeCommand, Response<int>>
    {
        private readonly IDyeingTBRecipeRepository _repository;

        public UpdateDyeingTBRecipeCommandHandler(IDyeingTBRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRecipeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DyeingTBRecipe Not Found.");

            entity.DyeingTBMaterialColorId = command.DyeingTBMaterialColorId;
            entity.TemplateId = command.TemplateId;
            entity.TemplateName = command.TemplateName;
            entity.TCFNo = command.TCFNo;
            entity.IsActive = command.IsActive;
            entity.ApproveVersionId = command.ApproveVersionId;
            entity.ApproveDate = command.ApproveDate;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}