using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.QCDefectTypes
{
    public class GetQCDefectTypeQuery : IRequest<Response<QCDefectType>>
    {
        public int Id { get; set; }
    }
    public class GetQCDefectTypeQueryHandler : IRequestHandler<GetQCDefectTypeQuery, Response<QCDefectType>>
    {
        private readonly IQCDefectTypeRepository _repository;
        public GetQCDefectTypeQueryHandler(IQCDefectTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<QCDefectType>> Handle(GetQCDefectTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new ($"QCDefectTypes Not Found (Id:{query.Id}).");
            return new Response<QCDefectType>(entity);
        }
    }
}
