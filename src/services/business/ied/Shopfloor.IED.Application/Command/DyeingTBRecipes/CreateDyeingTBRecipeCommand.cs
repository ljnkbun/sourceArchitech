using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingTBRTasks;
using Shopfloor.IED.Application.Command.DyeingTBRVersions;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRecipes
{
    public class CreateDyeingTBRecipeCommand : IRequest<Response<int>>
    {
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

        public virtual ICollection<CreateDyeingTBRVersionCommand> DyeingTBRVersions { get; set; }

        public virtual ICollection<CreateDyeingTBRTaskCommand> DyeingTBRTasks { get; set; }
    }

    public class CreateDyeingTBRecipeCommandHandler : IRequestHandler<CreateDyeingTBRecipeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRecipeRepository _repository;

        public CreateDyeingTBRecipeCommandHandler(IMapper mapper,
            IDyeingTBRecipeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingTBRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingTBRecipe>(request);
            await _repository.AddDyeingTBRecipeAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}