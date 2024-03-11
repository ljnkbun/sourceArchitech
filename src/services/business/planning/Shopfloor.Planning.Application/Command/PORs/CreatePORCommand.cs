using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Command.PORDetails;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.PORs
{
    public class CreatePORCommand : IRequest<Response<int>>
    {
        public int? WfxOCId { get; set; }
        public string OCNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? WfxPORId { get; set; }
        public string PORNo { get; set; }
        public string DivisionName { get; set; }
        public int? DivisionId { get; set; }
        public int? WfxArticleId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Buyer { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductGroup { get; set; }
        public int? BOMId { get; set; }
        public string BOMNo { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PORStatus? Status { get; set; }
        public OCStatus? OCStatus { get; set; }
        public string Type { get; set; }
        public bool IsAllocated { get; set; }
        public string ProcessName { get; set; }
        public int? ProcessId { get; set; }
        public bool? IsActive { get; set; }
        public string UOM { get; set; }
        public int? OrderId { get; set; }
        public string JobOrderNo { get; set; }
        public virtual ICollection<CreatePORDetailCommand> PORDetails { get; set; }
    }
    public class CreatePORCommandHandler : IRequestHandler<CreatePORCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPORRepository _repository;
        public CreatePORCommandHandler(IMapper mapper
            , IPORRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(CreatePORCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<POR>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
