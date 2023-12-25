using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Genders
{
    public class GetGenderQuery : IRequest<Response<Gender>>
    {
        public int Id { get; set; }
    }
    public class GetGenderQueryHandler : IRequestHandler<GetGenderQuery, Response<Gender>>
    {
        private readonly IGenderRepository _repository;
        public GetGenderQueryHandler(IGenderRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Gender>> Handle(GetGenderQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Gender Not Found (Id: {query.Id}).");
            return new Response<Gender>(entity);
        }
    }
}
