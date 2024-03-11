using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SubCategoryGroups
{
    public class GetSubCategoryGroupQuery : IRequest<Response<SubCategoryGroup>>
    {
        public int Id { get; set; }
    }
    public class GetSubCategoryGroupQueryHandler : IRequestHandler<GetSubCategoryGroupQuery, Response<SubCategoryGroup>>
    {
        private readonly ISubCategoryGroupRepository _repository;
        public GetSubCategoryGroupQueryHandler(ISubCategoryGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SubCategoryGroup>> Handle(GetSubCategoryGroupQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"SubCategoryGroup Not Found (Id:{query.Id}).");
            return new Response<SubCategoryGroup>(entity);
        }
    }
}
