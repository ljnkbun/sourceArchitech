using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Lines
{
    public class GetLineQuery : IRequest<Response<Line>>
    {
        public int Id { get; set; }
    }
    public class GetLineQueryHandler : IRequestHandler<GetLineQuery, Response<Line>>
    {
        private readonly ILineRepository _repository;
        public GetLineQueryHandler(ILineRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Line>> Handle(GetLineQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Line Not Found (Id:{query.Id}).");
            return new Response<Line>(entity);
        }
    }
}
