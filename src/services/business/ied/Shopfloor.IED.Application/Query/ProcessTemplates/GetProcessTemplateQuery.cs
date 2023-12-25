using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.ProcessTemplates
{
    public class GetProcessTemplateQuery : IRequest<Response<ProcessTemplate>>
    {
        public int Id { get; set; }
    }
    public class GetProcessTemplateQueryHandler : IRequestHandler<GetProcessTemplateQuery, Response<ProcessTemplate>>
    {
        private readonly IProcessTemplateRepository _repository;
        public GetProcessTemplateQueryHandler(IProcessTemplateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProcessTemplate>> Handle(GetProcessTemplateQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"ProcessTemplate Not Found (Id:{query.Id}).");
            return new Response<ProcessTemplate>(entity);
        }
    }
}
