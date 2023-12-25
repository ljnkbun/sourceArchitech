using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DCTemplateTasks
{
    public class GetDCTemplateTaskQuery : IRequest<Response<Domain.Entities.DCTemplateTask>>
    {
        public int Id { get; set; }
    }

    public class GetDCTemplateTaskQueryHandler : IRequestHandler<GetDCTemplateTaskQuery, Response<Domain.Entities.DCTemplateTask>>
    {
        private readonly IDCTemplateTaskRepository _repository;

        public GetDCTemplateTaskQueryHandler(IDCTemplateTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DCTemplateTask>> Handle(GetDCTemplateTaskQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"DCTemplateTask Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DCTemplateTask>(entity);
        }
    }
}