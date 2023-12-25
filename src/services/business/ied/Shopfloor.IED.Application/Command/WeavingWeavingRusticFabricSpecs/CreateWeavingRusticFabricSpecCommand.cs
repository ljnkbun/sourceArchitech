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
        public string BackgroundType { get; set; }
        public decimal BackgroundLoomFrame { get; set; }
        public string BorderType { get; set; }
        public decimal BorderLoomFrame { get; set; }
        public decimal WeightGM { get; set; }
        public decimal WeightGM2 { get; set; }
        public decimal VerticalShrinkage { get; set; }
        public decimal HorizontalShrinkage { get; set; }
        public string MachineType { get; set; }
        public decimal RPM { get; set; }
        public decimal CombNum { get; set; }
        public decimal CombSize { get; set; }
        public decimal VerticalDensity { get; set; }
        public decimal HorizontalDensity { get; set; }
        public decimal RusticSize { get; set; }
        public decimal HorizontalDensitySetting { get; set; }
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
