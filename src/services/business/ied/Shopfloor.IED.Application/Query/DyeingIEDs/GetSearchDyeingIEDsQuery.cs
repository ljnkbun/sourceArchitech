using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingIEDs;
using Shopfloor.IED.Application.Parameters.DyeingIEDs;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingIEDs
{
    public class GetSearchDyeingIEDsQuery : IRequest<PagedResponse<IReadOnlyList<SearchDyeingIEDModel>>>, ICacheableMediatrQuery
    {
        public Status? Status { get; set; }

        public string RequestNo { get; set; }

        public string RequestType { get; set; }

        public string ArticleName { get; set; }

        public string ProductGroup { get; set; }

        public string SubCategory { get; set; }

        public string Buyer { get; set; }

        public DateTime? ExpectedDate { get; set; }

        public string Creator { get; set; }

        public string Department { get; set; }

        public string RecipeNo { get; set; }

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
        public bool BypassCache { get; set; }
        public string CacheKey => $"DyeingIEDs";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetSearchDyeingIEDsQueryHandler : IRequestHandler<GetSearchDyeingIEDsQuery, PagedResponse<IReadOnlyList<SearchDyeingIEDModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingIEDRepository _repository;

        public GetSearchDyeingIEDsQueryHandler(IMapper mapper,
            IDyeingIEDRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SearchDyeingIEDModel>>> Handle(GetSearchDyeingIEDsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SearchDyeingIEDParameter>(request);
            return await _repository.GetSearchDyeingIEDPagedResponseAsync<SearchDyeingIEDParameter, SearchDyeingIEDModel>(validFilter);
        }
    }
}