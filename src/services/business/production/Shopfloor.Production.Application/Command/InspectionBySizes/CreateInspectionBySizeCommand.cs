using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.InspectionBySizes
{
    public class CreateInspectionBySizeCommand : IRequest<Response<int>>
    {
        public int? ProductionOutputId { get; set; }
        public int? ArticleBarcodeId { get; set; }
        public int? FPPOOutputDetailId { get; set; }
        public decimal? OKQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BGroupQty { get; set; }
        public decimal? RejectQty { get; set; }
        public decimal? Length { get; set; }
        public decimal? Weight { get; set; }
        public decimal? ActualWeight { get; set; }
        public decimal? CaptureMeter { get; set; }
        public decimal? CuttingWidth { get; set; }
        public decimal? WarpDensity { get; set; }
        public decimal? WeftDensity { get; set; }
    }
    public class CreateInspectionBySizeCommandHandler : IRequestHandler<CreateInspectionBySizeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionBySizeRepository _repository;
        public CreateInspectionBySizeCommandHandler(IMapper mapper,
            IInspectionBySizeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInspectionBySizeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InspectionBySize>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
