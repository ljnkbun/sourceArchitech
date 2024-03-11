using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SpinningMethods
{
    public class GetSpinningMethodQuery : IRequest<Response<SpinningMethod>>
    {
        public int Id { get; set; }
    }
    public class GetSpinningMethodQueryHandler : IRequestHandler<GetSpinningMethodQuery, Response<SpinningMethod>>
    {
        private readonly ISpinningMethodRepository _repository;
        public GetSpinningMethodQueryHandler(ISpinningMethodRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SpinningMethod>> Handle(GetSpinningMethodQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"SpinningMethod Not Found (Id:{query.Id}).");
            return new Response<SpinningMethod>(entity);
        }
    }
}
