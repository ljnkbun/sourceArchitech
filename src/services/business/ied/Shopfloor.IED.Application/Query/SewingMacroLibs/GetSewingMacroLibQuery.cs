using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingMacroLibs
{
    public class GetSewingMacroLibQuery : IRequest<Response<SewingMacroLib>>
    {
        public int Id { get; set; }
    }
    public class GetSewingMacroLibQueryHandler : IRequestHandler<GetSewingMacroLibQuery, Response<SewingMacroLib>>
    {
        private readonly ISewingMacroLibRepository _repository;
        public GetSewingMacroLibQueryHandler(ISewingMacroLibRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingMacroLib>> Handle(GetSewingMacroLibQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetSewingMacroLibByIdAsync(query.Id);
            if (entity == null) return new($"SewingMacroLib Not Found (Id:{query.Id}).");
            return new Response<SewingMacroLib>(entity);
        }
    }
}
