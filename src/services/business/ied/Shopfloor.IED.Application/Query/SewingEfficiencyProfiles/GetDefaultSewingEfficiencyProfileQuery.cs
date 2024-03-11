using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingEfficiencyProfiles
{
    public record GetDefaultSewingEfficiencyProfileQuery : IRequest<Response<SewingEfficiencyProfile>>
    { }
    public class GetDefaultSewingEfficiencyProfileQueryHandler : IRequestHandler<GetDefaultSewingEfficiencyProfileQuery, Response<SewingEfficiencyProfile>>
    {
        private readonly ISewingEfficiencyProfileRepository _repository;

        public GetDefaultSewingEfficiencyProfileQueryHandler(ISewingEfficiencyProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<SewingEfficiencyProfile>> Handle(GetDefaultSewingEfficiencyProfileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetDefaultSewingEfficiencyProfileAsync();
            if (entity == null) return new($"Default SewingEfficiencyProfile Not Found.");
            return new Response<SewingEfficiencyProfile>(entity);
        }
    }
}