using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingTaskLibs
{
    public class GetSewingTaskLibQuery : IRequest<Response<SewingTaskLib>>
    {
        public int Id { get; set; }
    }
    public class GetSewingTaskLibQueryHandler : IRequestHandler<GetSewingTaskLibQuery, Response<SewingTaskLib>>
    {
        private readonly ISewingTaskLibRepository _repository;
        public GetSewingTaskLibQueryHandler(ISewingTaskLibRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingTaskLib>> Handle(GetSewingTaskLibQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"SewingTaskLib Not Found (Id:{query.Id}).");
            return new Response<SewingTaskLib>(entity);
        }
    }
}
