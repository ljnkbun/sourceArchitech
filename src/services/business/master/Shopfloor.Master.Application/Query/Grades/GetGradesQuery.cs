using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Grades;
using Shopfloor.Master.Application.Parameters.FiberTypes;
using Shopfloor.Master.Application.Parameters.Grades;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Grades
{
    public class GetGradesQuery : IRequest<PagedResponse<IReadOnlyList<GradeModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Grades";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetGradesQueryHandler : IRequestHandler<GetGradesQuery, PagedResponse<IReadOnlyList<GradeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IGradeRepository _repository;
        public GetGradesQueryHandler(IMapper mapper,
            IGradeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<GradeModel>>> Handle(GetGradesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GradeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(GradeParameter.Code), nameof(GradeParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<GradeParameter, GradeModel>(validFilter);

        }
    }
}
