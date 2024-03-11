using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.DefectCapturingStandards
{
    public class GetDefectCapturingStandardQuery : IRequest<Response<DefectCapturingStandard>>
    {
        public int Id { get; set; }
    }
    public class GetDefectCapturingStandardQueryHandler : IRequestHandler<GetDefectCapturingStandardQuery, Response<DefectCapturingStandard>>
    {
        private readonly IDefectCapturingStandardRepository _repository;
        public GetDefectCapturingStandardQueryHandler(IDefectCapturingStandardRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<DefectCapturingStandard>> Handle(GetDefectCapturingStandardQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"DefectCapturingStandard Not Found (Id:{query.Id}).");
            return new Response<DefectCapturingStandard>(entity);
        }
    }
}
