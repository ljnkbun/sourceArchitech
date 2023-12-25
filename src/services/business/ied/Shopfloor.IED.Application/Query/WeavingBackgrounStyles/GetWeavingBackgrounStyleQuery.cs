using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingBackgrounStyles
{
    public class GetWeavingBackgrounStyleQuery : IRequest<Response<WeavingBackgrounStyle>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingBackgrounStyleQueryHandler : IRequestHandler<GetWeavingBackgrounStyleQuery, Response<WeavingBackgrounStyle>>
    {
        private readonly IWeavingBackgrounStyleRepository _repository;
        public GetWeavingBackgrounStyleQueryHandler(IWeavingBackgrounStyleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingBackgrounStyle>> Handle(GetWeavingBackgrounStyleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"WeavingBackgrounStyle Not Found (Id:{query.Id}).");
            return new Response<WeavingBackgrounStyle>(entity);
        }
    }
}
