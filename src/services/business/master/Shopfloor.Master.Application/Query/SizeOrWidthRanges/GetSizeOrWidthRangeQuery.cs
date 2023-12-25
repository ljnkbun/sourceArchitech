using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SizeOrWidthRanges
{
    public class GetSizeOrWidthRangeQuery : IRequest<Response<SizeOrWidthRange>>
    {
        public int Id { get; set; }
    }
    public class GetSizeOrWidthRangeQueryHandler : IRequestHandler<GetSizeOrWidthRangeQuery, Response<SizeOrWidthRange>>
    {
        private readonly ISizeOrWidthRangeRepository _repository;
        public GetSizeOrWidthRangeQueryHandler(ISizeOrWidthRangeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SizeOrWidthRange>> Handle(GetSizeOrWidthRangeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"SizeOrWidthRange Not Found (Id: {query.Id}).");
            return new Response<SizeOrWidthRange>(entity);
        }
    }
}
