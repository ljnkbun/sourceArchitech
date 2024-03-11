using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.QCDefects
{
    public class GetQCDefectQuery : IRequest<Response<QCDefect>>
    {
        public int Id { get; set; }
    }
    public class GetQCDefectQueryHandler : IRequestHandler<GetQCDefectQuery, Response<QCDefect>>
    {
        private readonly IQCDefectRepository _repository;
        public GetQCDefectQueryHandler(IQCDefectRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<QCDefect>> Handle(GetQCDefectQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new ($"QCDefects Not Found (Id:{query.Id}).");
            return new Response<QCDefect>(entity);
        }
    }
}
