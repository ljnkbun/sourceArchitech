using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.FPPOs;
using Shopfloor.Planning.Application.Parameters.FPPOs;
using Shopfloor.Planning.Application.Query.FPPOs;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FPPOController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FPPOParameter filter)
        {
            return Ok(await Mediator.Send(new GetFPPOsQuery()
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                IsActive = filter.IsActive,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,

                StripScheduleId = filter.StripScheduleId,
                WFXFPPOId = filter.WFXFPPOId,
                FPPONo = filter.FPPONo,
                WFXOCId =filter.WFXOCId,
                OCNo = filter.OCNo,
                WFXDeliveryOrderCode = filter.WFXDeliveryOrderCode,
                Supplier = filter.Supplier,
                WipDispatchSite = filter.WipDispatchSite,
                WipReceivingSite = filter.WipReceivingSite,
                PORId = filter.PORId,
                PORNo = filter.PORNo,
                BatchNo = filter.BatchNo,
                JobOrderNo = filter.JobOrderNo,
                FactoryId = filter.FactoryId,
                LineId = filter.LineId,
                MachineId = filter.MachineId,
                ProcessId = filter.ProcessId,
                ProcessCode = filter.ProcessCode,
                ProcessName = filter.ProcessName,
                Start = filter.Start,
                End = filter.End,
                WFXArticleId = filter.WFXArticleId,
                ArticleName = filter.ArticleName,
                ArticleCode = filter.ArticleCode,
                UOM = filter.UOM,
                WFXSynced = filter.WFXSynced,
                Deleted = filter.Deleted
            }));
        }

        // GET: api/v1/<controller>/5
        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFPPOQuery() { Id = id }));
        }

        // POST:  api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateFPPOCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT:  api/v1/<controller>/5
        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, UpdateFPPOCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // POST:  api/v1/<controller>/5
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFPPOCommand() { Id = id }));
        }
    }
}
