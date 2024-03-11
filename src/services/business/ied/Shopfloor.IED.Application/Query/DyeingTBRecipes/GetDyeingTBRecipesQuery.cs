using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingTBRecipes;
using Shopfloor.IED.Application.Parameters.DyeingTBRecipes;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRecipes
{
    public class GetDyeingTBRecipesQuery : IRequest<PagedResponse<IReadOnlyList<DyeingTBRecipeModel>>>
    {
        public int? DyeingTBMaterialColorId { get; set; }

        public string TBRecipeNo { get; set; }

        public int? TemplateId { get; set; }

        public string TemplateName { get; set; }

        public string TBRecipeName { get; set; }

        public string TCFNo { get; set; }

        public int? ApproveVersionIndex { get; set; }

        public DateTime? ApproveDate { get; set; }

        public string Comment { get; set; }

        public string Buyer { get; set; }

        public string BuyerRef { get; set; }

        public string GarmentStyleRef { get; set; }

        public DateTime? ExpectedDate { get; set; }

        public string Color { get; set; }

        public string Concentration { get; set; }

        public int? VersionQty { get; set; }

        public TBRecipeStatus? Status { get; set; }

        #region Base Properties

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }

        #endregion Base Properties
    }

    public class GetDyeingTBRecipesQueryHandler : IRequestHandler<GetDyeingTBRecipesQuery, PagedResponse<IReadOnlyList<DyeingTBRecipeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRecipeRepository _repository;

        public GetDyeingTBRecipesQueryHandler(IMapper mapper,
            IDyeingTBRecipeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingTBRecipeModel>>> Handle(GetDyeingTBRecipesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingTBRecipeParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DyeingTBRecipeParameter, DyeingTBRecipeModel>(validFilter);
        }
    }
}