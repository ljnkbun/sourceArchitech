using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Categories
{
    public class GetCategoryQuery : IRequest<Response<Category>>
    {
        public int Id { get; set; }
    }
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Response<Category>>
    {
        private readonly ICategoryRepository _repository;
        public GetCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Category>> Handle(GetCategoryQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Category Not Found (Id:{query.Id}).");
            return new Response<Category>(entity);
        }
    }
}
