using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingSubOperationWFXBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingSubOperationWFXs
{
    public class CreateSewingSubOperationWFXCommand : IRequest<Response<int>>
    {
        public int SewingOperationWFXVersionId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string LineNumber { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalSMV { get; set; }
        public decimal NonMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public string QuatityPoints { get; set; }
        public string QualityComments { get; set; }
        public string Freq { get; set; }
        public decimal Effort { get; set; }
        public decimal AllowedTime { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<SewingSubOperationWFXBOLModel> SewingSubOperationWFXBOLs { get; set; }
    }
    public class CreateSewingSubOperationWFXCommandHandler : IRequestHandler<CreateSewingSubOperationWFXCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingSubOperationWFXRepository _repository;
        public CreateSewingSubOperationWFXCommandHandler(IMapper mapper,
            ISewingSubOperationWFXRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingSubOperationWFXCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingSubOperationWFX>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
