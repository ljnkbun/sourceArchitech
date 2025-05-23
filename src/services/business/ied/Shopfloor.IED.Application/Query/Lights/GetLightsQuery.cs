﻿using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.Lights;
using Shopfloor.IED.Application.Parameters.Lights;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Lights
{
    public class GetLightsQuery : IRequest<PagedResponse<IReadOnlyList<LightModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Lights";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetLightsQueryHandler : IRequestHandler<GetLightsQuery, PagedResponse<IReadOnlyList<LightModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ILightRepository _repository;
        public GetLightsQueryHandler(IMapper mapper,
            ILightRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<LightModel>>> Handle(GetLightsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<LightParameter>(request);
            return await _repository.GetModelPagedReponseAsync<LightParameter, LightModel>(validFilter);
        }
    }
}
