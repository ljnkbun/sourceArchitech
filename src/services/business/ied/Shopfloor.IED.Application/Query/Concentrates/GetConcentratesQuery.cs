﻿using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.Concentrates;
using Shopfloor.IED.Application.Parameters.Concentrates;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Concentrates
{
    public class GetConcentratesQuery : IRequest<PagedResponse<IReadOnlyList<ConcentrateModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Concentrates";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetConcentratesQueryHandler : IRequestHandler<GetConcentratesQuery, PagedResponse<IReadOnlyList<ConcentrateModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IConcentrateRepository _repository;
        public GetConcentratesQueryHandler(IMapper mapper,
            IConcentrateRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ConcentrateModel>>> Handle(GetConcentratesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ConcentrateParameter>(request);
            return await _repository.GetModelPagedReponseAsync<ConcentrateParameter, ConcentrateModel>(validFilter);
        }
    }
}
