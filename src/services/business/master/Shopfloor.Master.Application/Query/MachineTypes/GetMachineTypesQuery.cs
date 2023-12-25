using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.MachineTypes;
using Shopfloor.Master.Application.Parameters.Staples;
using Shopfloor.Master.Application.Parameters.MachineTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.MachineTypes
{
    public class GetMachineTypesQuery : IRequest<PagedResponse<IReadOnlyList<MachineTypeModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"MachineTypes";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetMachineTypesQueryHandler : IRequestHandler<GetMachineTypesQuery, PagedResponse<IReadOnlyList<MachineTypeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IMachineTypeRepository _repository;
        public GetMachineTypesQueryHandler(IMapper mapper,
            IMachineTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<MachineTypeModel>>> Handle(GetMachineTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<MachineTypeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(MachineTypeParameter.Code), nameof(MachineTypeParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<MachineTypeParameter, MachineTypeModel>(validFilter);
        }
    }
}
