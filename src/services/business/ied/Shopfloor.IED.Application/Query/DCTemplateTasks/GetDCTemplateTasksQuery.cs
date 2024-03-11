using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DCTemplateTasks;
using Shopfloor.IED.Application.Parameters.DCTemplateTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DCTemplateTasks
{
    public class GetDCTemplateTasksQuery : IRequest<PagedResponse<IReadOnlyList<DCTemplateTaskModel>>>
    {
        public int? DCTemplateId { get; set; }
        public int? DyeingProcessId { get; set; }
        public string DyeingProcessName { get; set; }
        public int? DyeingOpreationId { get; set; }
        public string DyeingOpreationName { get; set; }
        public int? LineNumber { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public string Temperature { get; set; }
        public int? Minute { get; set; }

        #region Base Properties

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }

        #endregion Base Properties
    }

    public class GetDCTemplateTasksQueryHandler : IRequestHandler<GetDCTemplateTasksQuery, PagedResponse<IReadOnlyList<DCTemplateTaskModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDCTemplateTaskRepository _repository;

        public GetDCTemplateTasksQueryHandler(IMapper mapper,
            IDCTemplateTaskRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DCTemplateTaskModel>>> Handle(GetDCTemplateTasksQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DCTemplateTaskParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DCTemplateTaskParameter, DCTemplateTaskModel>(validFilter);
        }
    }
}