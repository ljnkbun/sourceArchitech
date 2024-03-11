using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.Imports;
using Shopfloor.Inspection.Application.Command.QCRequests;
using Shopfloor.Inspection.Application.Parameters.QCRequests;
using Shopfloor.Inspection.Application.Query.QCRequests;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class QCRequestController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QCRequestParameter filter)
        {
            return Ok(await Mediator.Send(new GetQCRequestsQuery()
            {
                ProductionOutputCode=filter.ProductionOutputCode,
				QCRequestDate = filter.QCRequestDate,
				SiteCode = filter.SiteCode,
				SiteName = filter.SiteName,
				SupplierName = filter.SupplierName,
				QCRequestNo = filter.QCRequestNo,
				Category = filter.Category,
				QCRequestStatus = filter.QCRequestStatus,
				TransferStatus = filter.TransferStatus,
				DocumentNo = filter.DocumentNo,
				QCDefinitionCode = filter.QCDefinitionCode,
				RequestedQty = filter.RequestedQty,
                FromDate = filter.FromDate,
                ToDate = filter.ToDate,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetQCRequestQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateQCRequestCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateQCRequestCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteQCRequestCommand { Id = id }));
        }
        // PUT api/v1/<controller>/5
        [HttpPut("Status")]
        public async Task<IActionResult> Put(UpdateQCRequestStatusCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
