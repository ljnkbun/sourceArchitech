using Microsoft.AspNetCore.Mvc;

using Shopfloor.Material.Application.Command.PriceLists;
using Shopfloor.Material.Application.Parameters.PriceLists;
using Shopfloor.Material.Application.Query.PriceLists;

namespace Shopfloor.Material.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PriceListController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PriceListParameter filter)
        {
            return Ok(await Mediator.Send(new GetPriceListsQuery()
            {
                RequestNo = filter.RequestNo,
                CategoryCode = filter.CategoryCode,
                SupplierName = filter.SupplierName,
                CategoryName = filter.CategoryName,
                SupplierCode = filter.SupplierCode,
                ReasonReject = filter.ReasonReject,
                ApproveUserId = filter.ApproveUserId,
                ApproveName = filter.ApproveName,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                CreatedFrom = filter.CreatedFrom,
                CreatedTo = filter.CreatedTo,
                IsActive = filter.IsActive,
                Status = filter.Status,
                BypassCache = filter.BypassCache,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPriceListQuery() { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreatePriceListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdatePriceListCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePriceListCommand { Id = id }));
        }

        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            return Ok(await Mediator.Send(new ApprovePriceListCommand { Id = id }));
        }

        [HttpPut("SendApprove/{id}")]
        public async Task<IActionResult> SendApprove(int id)
        {
            return Ok(await Mediator.Send(new SendApprovePriceListCommand { Id = id }));
        }

        [HttpPut("Reject/{id}")]
        public async Task<IActionResult> Reject(int id, RejectPriceListCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPut("SendExport/{id}")]
        public async Task<IActionResult> SendExport(int id)
        {
            return Ok(await Mediator.Send(new SendExportPriceListCommand { Id = id }));
        }

        [HttpPost("Import")]
        public async Task<IActionResult> Import(IFormFile file)
        {
            return Ok(await Mediator.Send(new ImportPriceListCommand { File = file }));
        }

        [HttpGet("ExportExcel")]
        public async Task<IActionResult> ExportExcel([FromQuery] ExportPriceListParameter model)
        {
            return await Mediator.Send(new ExportPriceListQuery { Ids = model.Ids });
        }
    }
}