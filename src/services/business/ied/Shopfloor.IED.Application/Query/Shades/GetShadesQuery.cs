﻿using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.Shades;
using Shopfloor.IED.Application.Parameters.Shades;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Shades
{
    public class GetShadesQuery : IRequest<PagedResponse<IReadOnlyList<ShadeModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Shades";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetShadesQueryHandler : IRequestHandler<GetShadesQuery, PagedResponse<IReadOnlyList<ShadeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IShadeRepository _repository;
        public GetShadesQueryHandler(IMapper mapper,
            IShadeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ShadeModel>>> Handle(GetShadesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ShadeParameter>(request);
            return await _repository.GetModelPagedReponseAsync<ShadeParameter, ShadeModel>(validFilter);
        }
    }
}
