using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DCTemplates
{
    public class GetDCTemplateQuery : IRequest<Response<Domain.Entities.DCTemplate>>
    {
        public int Id { get; set; }
    }

    public class GetDCTemplateQueryHandler : IRequestHandler<GetDCTemplateQuery, Response<Domain.Entities.DCTemplate>>
    {
        private readonly IDCTemplateRepository _repository;

        public GetDCTemplateQueryHandler(IDCTemplateRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DCTemplate>> Handle(GetDCTemplateQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"DCTemplate Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DCTemplate>(entity);
        }
    }
}