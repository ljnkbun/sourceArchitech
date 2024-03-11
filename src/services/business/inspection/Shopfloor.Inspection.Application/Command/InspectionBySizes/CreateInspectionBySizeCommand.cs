using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionBySizes
{
    public class CreateInspectionBySizeCommand : IRequest<Response<int>>
    {
        public string ColorCode { get; set; }
		public string ColorName { get; set; }
		public string SizeCode { get; set; }
		public string SizeName { get; set; }
		public string Shade { get; set; }
		public string Lot { get; set; }
		public decimal GRNQty { get; set; }
		public decimal PreInspectedQty { get; set; }
		public decimal LotQty { get; set; }
		public decimal InspectionQty { get; set; }
		public decimal ActualQty { get; set; }
		public int NoOfDefect { get; set; }
		public decimal OKQty { get; set; }
		public decimal BGroupQty { get; set; }
		public decimal BGroupUsable { get; set; }
		public decimal RejectedQty { get; set; }
		public decimal ExcessShortageQty { get; set; }
		public string ReasonforBGroup { get; set; }
        public int? QCRequestDetailId { get; set; }
        public int InspectionId { get; set; }
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
