using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.OneHundredPointSystemDetails;
using Shopfloor.Inspection.Application.Parameters.OneHundredPointSystemDetails;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Query.OneHundredPointSystemDetails
{
    public class GetOneHundredPointSystemDetailsQuery : IRequest<PagedResponse<IReadOnlyList<OneHundredPointSystemDetailModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public decimal? FromKg { get; set; }
		public decimal? ToKg { get; set; }
		public int? FromDefect { get; set; }
		public int? ToDefect { get; set; }
		public OneHundredPointType? Point { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetOneHundredPointSystemDetailsQueryHandler : IRequestHandler<GetOneHundredPointSystemDetailsQuery, PagedResponse<IReadOnlyList<OneHundredPointSystemDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IOneHundredPointSystemDetailRepository _repository;
        public GetOneHundredPointSystemDetailsQueryHandler(IMapper mapper,
            IOneHundredPointSystemDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<OneHundredPointSystemDetailModel>>> Handle(GetOneHundredPointSystemDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<OneHundredPointSystemDetailParameter>(request);
            return await _repository.GetModelPagedReponseAsync<OneHundredPointSystemDetailParameter, OneHundredPointSystemDetailModel>(validFilter);
        }
    }
}
