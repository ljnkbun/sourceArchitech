using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Departments;
using Shopfloor.Master.Application.Parameters.Currencies;
using Shopfloor.Master.Application.Parameters.Departments;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Departments
{
    public class GetDepartmentsQuery : IRequest<PagedResponse<IReadOnlyList<DepartmentModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Departments";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, PagedResponse<IReadOnlyList<DepartmentModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _repository;
        public GetDepartmentsQueryHandler(IMapper mapper,
            IDepartmentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DepartmentModel>>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DepartmentParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(DepartmentParameter.Code), nameof(DepartmentParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<DepartmentParameter, DepartmentModel>(validFilter);
        }
    }
}
