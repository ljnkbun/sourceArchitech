using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.DynamicColumns
{
    public class GetDynamicColumnQuery : IRequest<Response<Domain.Entities.DynamicColumn>>
    {
        public int Id { get; set; }
    }

    public class GetDynamicColumnQueryHandler : IRequestHandler<GetDynamicColumnQuery, Response<Domain.Entities.DynamicColumn>>
    {
        private readonly IDynamicColumnRepository _repository;

        public GetDynamicColumnQueryHandler(IDynamicColumnRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DynamicColumn>> Handle(GetDynamicColumnQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) return new($"DynamicColumn Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DynamicColumn>(entity);
        }
    }
}