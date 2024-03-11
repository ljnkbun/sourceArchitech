using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.QCRequests
{
    public class CreateQCRequestCommand : IRequest<Response<int>>
    {
		public DateTime QCRequestDate { get; set; }
		public string SiteCode { get; set; }
		public string SiteName { get; set; }
		public string SupplierName { get; set; }
		public string QCRequestNo { get; set; }
		public string Category { get; set; }
		public QCRequestStatus QCRequestStatus { get; set; }
		public TransferStatus TransferStatus { get; set; }
		public string DocumentNo { get; set; }
		public string QCDefinitionCode { get; set; }
		public decimal RequestedQty { get; set; }
        public string ProductionOutputCode { get; set; }
    }
    public class CreateQCRequestCommandHandler : IRequestHandler<CreateQCRequestCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IQCRequestRepository _repository;
        public CreateQCRequestCommandHandler(IMapper mapper,
            IQCRequestRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateQCRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<QCRequest>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
