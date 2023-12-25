using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.CropSeasons;
using Shopfloor.Master.Application.Parameters.CountTypes;
using Shopfloor.Master.Application.Parameters.CropSeasons;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.CropSeasons
{
    public class GetCropSeasonsQuery : IRequest<PagedResponse<IReadOnlyList<CropSeasonModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"CropSeasons";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetCropSeasonsQueryHandler : IRequestHandler<GetCropSeasonsQuery, PagedResponse<IReadOnlyList<CropSeasonModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICropSeasonRepository _repository;
        public GetCropSeasonsQueryHandler(IMapper mapper,
            ICropSeasonRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<CropSeasonModel>>> Handle(GetCropSeasonsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CropSeasonParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(CropSeasonParameter.Code), nameof(CropSeasonParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<CropSeasonParameter, CropSeasonModel>(validFilter);
        }
    }
}
