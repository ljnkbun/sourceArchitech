using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.QCTypes
{
    public class GetQCTypeQuery : IRequest<Response<QCType>>
    {
        public int Id { get; set; }
    }
    public class GetQCTypeQueryHandler : IRequestHandler<GetQCTypeQuery, Response<QCType>>
    {
        private readonly IQCTypeRepository _repository;
        public GetQCTypeQueryHandler(IQCTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<QCType>> Handle(GetQCTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new ($"QCTypes Not Found (Id:{query.Id}).");
            return new Response<QCType>(entity);
        }
    }
}
