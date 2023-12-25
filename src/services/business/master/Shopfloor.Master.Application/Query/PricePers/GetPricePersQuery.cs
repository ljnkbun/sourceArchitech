﻿using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.PricePers;
using Shopfloor.Master.Application.Parameters.PaymentTerms;
using Shopfloor.Master.Application.Parameters.PricePers;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.PricePers
{
    public class GetPricePersQuery : IRequest<PagedResponse<IReadOnlyList<PricePerModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"PricePers";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetPricePersQueryHandler : IRequestHandler<GetPricePersQuery, PagedResponse<IReadOnlyList<PricePerModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IPricePerRepository _repository;
        public GetPricePersQueryHandler(IMapper mapper,
            IPricePerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<PricePerModel>>> Handle(GetPricePersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<PricePerParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(PricePerParameter.Code), nameof(PricePerParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<PricePerParameter, PricePerModel>(validFilter);
        }
    }
}
