using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DCTemplateDetails
{
    public class CreateDCTemplateDetailCommand : IRequest<Response<int>>
    {
        public int DCTemplateTaskId { get; set; }
        public string ChemicalCode { get; set; }
        public string ChemicalName { get; set; }
        public string Unit { get; set; }
        public decimal Value { get; set; }
        public int LineNumber { get; set; }
    }

    public class CreateDCTemplateDetailCommandHandler : IRequestHandler<CreateDCTemplateDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDCTemplateDetailRepository _repository;

        public CreateDCTemplateDetailCommandHandler(IMapper mapper,
            IDCTemplateDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDCTemplateDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DCTemplateDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}