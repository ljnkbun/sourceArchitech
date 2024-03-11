using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.QCDefects
{
    public class GetQCDefectByIdsQuery : IRequest<Response<ICollection<QCDefect>>>
    {
        public string Ids { get; set; }
    }
    public class GetQCDefectByIdsQueryQueryHandler : IRequestHandler<GetQCDefectByIdsQuery, Response<ICollection<QCDefect>>>
    {
        private readonly IQCDefectRepository _repository;
        public GetQCDefectByIdsQueryQueryHandler(IQCDefectRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ICollection<QCDefect>>> Handle(GetQCDefectByIdsQuery query, CancellationToken cancellationToken)
        {
            var arrId = query.Ids.Split(",").Select(x => int.Parse(x)).ToArray();
            var entity = await _repository.GetByIdsAsync(arrId);
            if (entity == null) return new ($"QCDefects Not Found (Ids:{query.Ids}).");
            return new Response<ICollection<QCDefect>>(entity);
        }
    }
}
