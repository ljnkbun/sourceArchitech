using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.ProfileEfficiencyDetails
{
    public class GetProfileEfficiencyDetailQuery : IRequest<Response<ProfileEfficiencyDetail>>
    {
        public int Id { get; set; }
    }
    public class GetProfileEfficiencyDetailQueryHandler : IRequestHandler<GetProfileEfficiencyDetailQuery, Response<ProfileEfficiencyDetail>>
    {
        private readonly IProfileEfficiencyDetailRepository _repository;
        public GetProfileEfficiencyDetailQueryHandler(IProfileEfficiencyDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProfileEfficiencyDetail>> Handle(GetProfileEfficiencyDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"ProfileEfficiencyDetail Not Found (Id:{query.Id}).");
            return new Response<ProfileEfficiencyDetail>(entity);
        }
    }
}
