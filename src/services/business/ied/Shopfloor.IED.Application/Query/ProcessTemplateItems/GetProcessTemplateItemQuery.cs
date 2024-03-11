using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.ProcessTemplateItems
{
    public class GetProcessTemplateItemQuery : IRequest<Response<ProcessTemplateItem>>
    {
        public int Id { get; set; }
    }
    public class GetProcessTemplateItemQueryHandler : IRequestHandler<GetProcessTemplateItemQuery, Response<ProcessTemplateItem>>
    {
        private readonly IProcessTemplateItemRepository _repository;
        public GetProcessTemplateItemQueryHandler(IProcessTemplateItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProcessTemplateItem>> Handle(GetProcessTemplateItemQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"ProcessTemplateItem Not Found (Id:{query.Id}).");
            return new Response<ProcessTemplateItem>(entity);
        }
    }
}
