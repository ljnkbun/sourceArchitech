using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.ProfileEfficiencies
{
    public class GetProfileEfficiencyQuery : IRequest<Response<ProfileEfficiency>>
    {
        public int Id { get; set; }
    }
    public class GetProfileEfficiencyQueryHandler : IRequestHandler<GetProfileEfficiencyQuery, Response<ProfileEfficiency>>
    {
        private readonly IProfileEfficiencyRepository _repository;
        public GetProfileEfficiencyQueryHandler(IProfileEfficiencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProfileEfficiency>> Handle(GetProfileEfficiencyQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"ProfileEfficiency Not Found (Id:{query.Id}).");
            return new Response<ProfileEfficiency>(entity);
        }
    }
}
