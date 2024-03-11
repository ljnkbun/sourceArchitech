using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingEfficiencyProfiles
{
    public class GetSewingEfficiencyProfileQuery : IRequest<Response<Domain.Entities.SewingEfficiencyProfile>>
    {
        public int Id { get; set; }
    }

    public class GetSewingEfficiencyProfileQueryHandler : IRequestHandler<GetSewingEfficiencyProfileQuery, Response<Domain.Entities.SewingEfficiencyProfile>>
    {
        private readonly ISewingEfficiencyProfileRepository _repository;

        public GetSewingEfficiencyProfileQueryHandler(ISewingEfficiencyProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.SewingEfficiencyProfile>> Handle(GetSewingEfficiencyProfileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) return new($"SewingEfficiencyProfile Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.SewingEfficiencyProfile>(entity);
        }
    }
}