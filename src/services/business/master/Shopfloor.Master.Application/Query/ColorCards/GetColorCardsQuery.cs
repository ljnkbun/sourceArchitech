using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.ColorCards;
using Shopfloor.Master.Application.Parameters.Certificates;
using Shopfloor.Master.Application.Parameters.ColorCards;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.ColorCards
{
    public class GetColorCardsQuery : IRequest<PagedResponse<IReadOnlyList<ColorCardModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string Reference { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string SelectColor { get; set; }
        public string PictureURL { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ColorCards";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetColorCardsQueryHandler : IRequestHandler<GetColorCardsQuery, PagedResponse<IReadOnlyList<ColorCardModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IColorCardRepository _repository;
        public GetColorCardsQueryHandler(IMapper mapper,
            IColorCardRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ColorCardModel>>> Handle(GetColorCardsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ColorCardParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ColorCardParameter.Code), nameof(ColorCardParameter.Name), nameof(ColorCardParameter.Reference), nameof(ColorCardParameter.BuyerCode), nameof(ColorCardParameter.BuyerName) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ColorCardParameter, ColorCardModel>(validFilter);
        }
    }
}
