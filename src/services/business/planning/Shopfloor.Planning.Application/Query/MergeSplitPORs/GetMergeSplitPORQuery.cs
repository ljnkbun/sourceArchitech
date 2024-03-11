using MediatR;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Query.MergeSplitPORs
{
    public class GetMergeSplitPORQuery : IRequest<Response<MergeSplitPOR>>
    {
        public int Id { get; set; }
    }
    public class GetMergeSplitPORQueryHandler : IRequestHandler<GetMergeSplitPORQuery, Response<MergeSplitPOR>>
    {
        private readonly IMergeSplitPORRepository _repository;
        public GetMergeSplitPORQueryHandler(IMergeSplitPORRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<MergeSplitPOR>> Handle(GetMergeSplitPORQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"MergeSplitPORs Not Found (Id:{query.Id}).");
            return new Response<MergeSplitPOR>(entity);
        }
    }
}
