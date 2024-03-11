using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Machines;
using Shopfloor.Master.Application.Parameters.Machines;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Machines
{
    public class GetMachinesQuery : IRequest<PagedResponse<IReadOnlyList<MachineModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string Remarks { get; set; }
        public decimal? Capacity { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
        public string Gauge { get; set; }
        public string MachineDiameter { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Machines";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetMachinesQueryHandler : IRequestHandler<GetMachinesQuery, PagedResponse<IReadOnlyList<MachineModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IMachineRepository _repository;
        public GetMachinesQueryHandler(IMapper mapper,
            IMachineRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<MachineModel>>> Handle(GetMachinesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<MachineParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(MachineParameter.Code), nameof(MachineParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<MachineParameter, MachineModel>(validFilter);
        }
    }
}
