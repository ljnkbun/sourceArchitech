using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingMacros
{
    public class GetSewingMacroQuery : IRequest<Response<SewingMacro>>
    {
        public int Id { get; set; }
    }
    public class GetSewingMacroQueryHandler : IRequestHandler<GetSewingMacroQuery, Response<SewingMacro>>
    {
        private readonly ISewingMacroRepository _repository;
        public GetSewingMacroQueryHandler(ISewingMacroRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingMacro>> Handle(GetSewingMacroQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetSewingMacroByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"SewingMacro Not Found (Id:{query.Id}).");
            return new Response<SewingMacro>(entity);
        }
    }
}
