using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.QCRequests
{
    public class UpdateQCRequestCommand : IRequest<Response<int>>
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
		public string WFXQCDefName { get; set; }
		public string QCDefinitionCode { get; set; }
		public decimal RequestedQty { get; set; }
        public int Id { get; set; }
        public bool IsActive { set; get; }
        public string ProductionOutputCode { get; set; }
    }
    public class UpdateQCRequestCommandHandler : IRequestHandler<UpdateQCRequestCommand, Response<int>>
    {
        private readonly IQCRequestRepository _repository;
        public UpdateQCRequestCommandHandler(IQCRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateQCRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"QCRequest Not Found.");
            entity.IsActive = command.IsActive;
			entity.QCRequestDate = command.QCRequestDate;
			entity.SiteCode = command.SiteCode;
			entity.SiteName = command.SiteName;
			entity.SupplierName = command.SupplierName;
			entity.QCRequestNo = command.QCRequestNo;
			entity.Category = command.Category;
			entity.QCRequestStatus = command.QCRequestStatus;
			entity.TransferStatus = command.TransferStatus;
			entity.DocumentNo = command.DocumentNo;
			entity.ProductionOutputCode = command.ProductionOutputCode;
			entity.QCDefinitionCode = command.QCDefinitionCode;
			entity.RequestedQty = command.RequestedQty;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
