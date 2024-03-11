using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.QCDefects;
using Shopfloor.Inspection.Application.Parameters.QCDefects;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Query.QCDefects
{
    public class GetQCDefectsQuery : IRequest<PagedResponse<IReadOnlyList<QCDefectModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? QCDefecTypeId { get; set; }
		public int? ParrentId { get; set; }
		public string NameEN { get; set; }
		public int? DivisonId { get; set; }
		public string DivisonName { get; set; }
		public int? ProcessId { get; set; }
		public string ProcessName { get; set; }
		public int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string SubCategoryId { get; set; }
		public string SubCategoryName { get; set; }
		public int? Level { get; set; }
		public InspectionType? InspectionType { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"QCDefects";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetQCDefectsQueryHandler : IRequestHandler<GetQCDefectsQuery, PagedResponse<IReadOnlyList<QCDefectModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IQCDefectRepository _repository;
        public GetQCDefectsQueryHandler(IMapper mapper,
            IQCDefectRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<QCDefectModel>>> Handle(GetQCDefectsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<QCDefectParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(QCDefectParameter.Code), nameof(QCDefectParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<QCDefectParameter, QCDefectModel>(validFilter);
        }
    }
}
