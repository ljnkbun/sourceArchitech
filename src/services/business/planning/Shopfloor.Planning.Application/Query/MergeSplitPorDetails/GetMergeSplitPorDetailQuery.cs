using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.MergeSplitPorDetails
{
    public class GetMergeSplitPorDetailQuery : IRequest<Response<MergeSplitPorDetail>>
    {
        public int Id { get; set; }
    }
    public class GetMergeSplitPorDetailQueryHandler : IRequestHandler<GetMergeSplitPorDetailQuery, Response<MergeSplitPorDetail>>
    {
        private readonly IMergeSplitPorDetailRepostiry _repository;
        public GetMergeSplitPorDetailQueryHandler(IMergeSplitPorDetailRepostiry repository)
        {
            _repository = repository;
        }
        public async Task<Response<MergeSplitPorDetail>> Handle(GetMergeSplitPorDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"MergeSplitPORDetails Not Found (Id:{query.Id}).");
            return new Response<MergeSplitPorDetail>(entity);
        }
    }
}
