using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.WfxGDIs
{
    public class CreateWfxGDICommand : IRequest<Response<int>>
    {
        public string GDINum { get; set; }
        public DateTime? GDICreationDate { get; set; }
        public string GDIType { get; set; }
        public string OrderRefNum { get; set; }
        public DateTime? OrderCreationDate { get; set; }
        public string WFXArticleCode { get; set; }
        public string WFXArticleName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public string FPPOOCNUm { get; set; }
        public string BuyerStyleRef { get; set; }
        public string RollNo { get; set; }
        public string RollBarcode { get; set; }
        public string ParentRollBarcode { get; set; }
        public string UOM { get; set; }
        public string RollOCRefNum { get; set; }
        public string Shade { get; set; }
        public string Location { get; set; }
        public int? LocationId { get; set; }
        public string WareHouse { get; set; }
        public string InternalShade { get; set; }
        public decimal? GDIPendingUnits { get; set; }
        public decimal? RollUnits { get; set; }
    }
    public class CreateWfxGDICommandHandler : IRequestHandler<CreateWfxGDICommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxGDIRepository _repository;
        public CreateWfxGDICommandHandler(IMapper mapper,
            IWfxGDIRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWfxGDICommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WfxGDI>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
