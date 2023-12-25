using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DCTemplateDetails
{
    public class GetDCTemplateDetailQuery : IRequest<Response<Domain.Entities.DCTemplateDetail>>
    {
        public int Id { get; set; }
    }

    public class GetDCTemplateDetailQueryHandler : IRequestHandler<GetDCTemplateDetailQuery, Response<Domain.Entities.DCTemplateDetail>>
    {
        private readonly IDCTemplateDetailRepository _repository;

        public GetDCTemplateDetailQueryHandler(IDCTemplateDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.DCTemplateDetail>> Handle(GetDCTemplateDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"DCTemplateDetail Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.DCTemplateDetail>(entity);
        }
    }
}