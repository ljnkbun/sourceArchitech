using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRusticFabricSpecs
{
    public class CreateWeavingRusticFabricSpecCommand : IRequest<Response<int>>
    {
        public int WeavingIEDId { get; set; }
        public int LineNumber { get; set; }
        public string ContentWeaveStyle { get; set; }
        public decimal HarnessFrameCWS { get; set; }
        public string MarginWeaveStyle { get; set; }
        public decimal HarnessFrameMWS { get; set; }
        public decimal WeightGM { get; set; }
        public decimal WeightGM2 { get; set; }
        public decimal WarpShrinkage { get; set; }
        public decimal WeftShrinkage { get; set; }
        public string MachineType { get; set; }
        public decimal RPM { get; set; }
        public decimal ReedCount { get; set; }
        public decimal ReedWidth { get; set; }
        public decimal WarpDensity { get; set; }
        public decimal WeftDensity { get; set; }
        public decimal GreigeWidth { get; set; }
        public decimal SettingWeftDensity { get; set; }
    }
    public class CreateWeavingRusticFabricSpecCommandHandler : IRequestHandler<CreateWeavingRusticFabricSpecCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingRusticFabricSpecRepository _repository;
        public CreateWeavingRusticFabricSpecCommandHandler(IMapper mapper,
            IWeavingRusticFabricSpecRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingRusticFabricSpecCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingRusticFabricSpec>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
