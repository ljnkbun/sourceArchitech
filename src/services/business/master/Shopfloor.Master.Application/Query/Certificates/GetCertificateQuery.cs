using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Certificates
{
    public class GetCertificateQuery : IRequest<Response<Certificate>>
    {
        public int Id { get; set; }
    }
    public class GetCertificateQueryHandler : IRequestHandler<GetCertificateQuery, Response<Certificate>>
    {
        private readonly ICertificateRepository _repository;
        public GetCertificateQueryHandler(ICertificateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Certificate>> Handle(GetCertificateQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Certificate Not Found (Id:{query.Id}).");
            return new Response<Certificate>(entity);
        }
    }
}
