using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SubCategories
{
    public class GetSubCategoryQuery : IRequest<Response<SubCategory>>
    {
        public int Id { get; set; }
    }
    public class GetSubCategoryQueryHandler : IRequestHandler<GetSubCategoryQuery, Response<SubCategory>>
    {
        private readonly ISubCategoryRepository _repository;
        public GetSubCategoryQueryHandler(ISubCategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SubCategory>> Handle(GetSubCategoryQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"SubCategory Not Found (Id:{query.Id}).");
            return new Response<SubCategory>(entity);
        }
    }
}
