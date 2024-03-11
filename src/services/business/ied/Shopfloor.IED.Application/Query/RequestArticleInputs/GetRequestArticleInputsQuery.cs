using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.RequestArticleInputs;
using Shopfloor.IED.Application.Parameters.RequestArticleInputs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestArticleInputs
{
    public class GetRequestArticleInputsQuery : IRequest<PagedResponse<IReadOnlyList<RequestArticleInputModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? RequestArticleOutputId { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetRequestArticleInputsQueryHandler : IRequestHandler<GetRequestArticleInputsQuery, PagedResponse<IReadOnlyList<RequestArticleInputModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestArticleInputRepository _repository;
        public GetRequestArticleInputsQueryHandler(IMapper mapper,
            IRequestArticleInputRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RequestArticleInputModel>>> Handle(GetRequestArticleInputsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RequestArticleInputParameter>(request);
            return await _repository.GetModelPagedReponseAsync<RequestArticleInputParameter, RequestArticleInputModel>(validFilter);
        }
    }
}
