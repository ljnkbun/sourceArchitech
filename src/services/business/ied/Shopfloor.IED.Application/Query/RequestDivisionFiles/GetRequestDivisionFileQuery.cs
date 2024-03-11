using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestDivisionFiles
{
    public class GetRequestDivisionFileQuery : IRequest<Response<RequestDivisionFile>>
    {
        public int Id { get; set; }
    }
    public class GetRequestDivisionFileQueryHandler : IRequestHandler<GetRequestDivisionFileQuery, Response<RequestDivisionFile>>
    {
        private readonly IRequestDivisionFileRepository _repository;
        public GetRequestDivisionFileQueryHandler(IRequestDivisionFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<RequestDivisionFile>> Handle(GetRequestDivisionFileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"RequestDivisionFile Not Found (Id:{query.Id}).");
            return new Response<RequestDivisionFile>(entity);
        }
    }
}
