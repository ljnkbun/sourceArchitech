using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.QCTypes;
using Shopfloor.Inspection.Application.Parameters.QCTypes;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Query.QCTypes
{
    public class GetQCTypesQuery : IRequest<PagedResponse<IReadOnlyList<QCTypeModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public QCScreenType? QCScreenType { get; set; }

        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetQCTypesQueryHandler : IRequestHandler<GetQCTypesQuery, PagedResponse<IReadOnlyList<QCTypeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IQCTypeRepository _repository;
        public GetQCTypesQueryHandler(IMapper mapper,
            IQCTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<QCTypeModel>>> Handle(GetQCTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<QCTypeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(QCTypeParameter.Code), nameof(QCTypeParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<QCTypeParameter, QCTypeModel>(validFilter);
        }
    }
}
