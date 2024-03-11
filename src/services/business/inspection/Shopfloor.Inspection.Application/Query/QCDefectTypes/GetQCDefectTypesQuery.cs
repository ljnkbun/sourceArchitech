using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.QCDefectTypes;
using Shopfloor.Inspection.Application.Parameters.QCDefectTypes;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.QCDefectTypes
{
    public class GetQCDefectTypesQuery : IRequest<PagedResponse<IReadOnlyList<QCDefectTypeModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"QCDefectTypes";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetQCDefectTypesQueryHandler : IRequestHandler<GetQCDefectTypesQuery, PagedResponse<IReadOnlyList<QCDefectTypeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IQCDefectTypeRepository _repository;
        public GetQCDefectTypesQueryHandler(IMapper mapper,
            IQCDefectTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<QCDefectTypeModel>>> Handle(GetQCDefectTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<QCDefectTypeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(QCDefectTypeParameter.Code), nameof(QCDefectTypeParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<QCDefectTypeParameter, QCDefectTypeModel>(validFilter);
        }
    }
}
