using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Micronaires
{
    public class GetMicronaireQuery : IRequest<Response<Micronaire>>
    {
        public int Id { get; set; }
    }
    public class GetMicronaireQueryHandler : IRequestHandler<GetMicronaireQuery, Response<Micronaire>>
    {
        private readonly IMicronaireRepository _repository;
        public GetMicronaireQueryHandler(IMicronaireRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Micronaire>> Handle(GetMicronaireQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Micronaire Not Found (Id:{query.Id}).");
            return new Response<Micronaire>(entity);
        }
    }
}
