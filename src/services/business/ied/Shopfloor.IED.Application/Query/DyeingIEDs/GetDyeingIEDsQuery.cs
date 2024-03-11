using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingIEDs;
using Shopfloor.IED.Application.Parameters.DyeingIEDs;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingIEDs
{
    public class GetDyeingIEDsQuery : IRequest<PagedResponse<IReadOnlyList<DyeingIEDModel>>>
    {
        public int? RequestArticleOutputId { get; set; }

        public string RequestNo { get; set; }

        public int? RequestTypeId { get; set; }

        public int? WFXArticleId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string ProductGroup { get; set; }

        public string SubCategory { get; set; }

        public string Buyer { get; set; }

        public string Color { get; set; }

        public string ColorRef { get; set; }

        public int? RecipeId { get; set; }

        public Status? Status { get; set; }

        public string Comment { get; set; }
        public string RejectReason { get; set; }
        public string TCFNo { get; set; }
        public int? WFXInputMaterialId { get; set; }
        public string InputMaterialName { get; set; }

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

    public class GetDyeingIEDsQueryHandler : IRequestHandler<GetDyeingIEDsQuery, PagedResponse<IReadOnlyList<DyeingIEDModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingIEDRepository _repository;

        public GetDyeingIEDsQueryHandler(IMapper mapper,
            IDyeingIEDRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingIEDModel>>> Handle(GetDyeingIEDsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingIEDParameter>(request);
            return await _repository.GetDyeingIEDPagedResponseAsync<DyeingIEDParameter, DyeingIEDModel>(validFilter);
        }
    }
}