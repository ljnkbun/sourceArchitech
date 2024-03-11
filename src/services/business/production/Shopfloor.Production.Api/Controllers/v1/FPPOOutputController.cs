using Microsoft.AspNetCore.Mvc;
using Shopfloor.Production.Application.Command.FPPOOutputs;
using Shopfloor.Production.Application.Parameters.FPPOOutputs;
using Shopfloor.Production.Application.Query.FPPOOutputs;

namespace Shopfloor.Production.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FPPOOutputController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FPPOOutputParameter filter)
        {
            return Ok(await Mediator.Send(new GetFPPOOutputsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,

                OCNo = filter.OCNo,
                FPPONo = filter.FPPONo,
                ProcessCode = filter.ProcessCode,
                ProcessName = filter.ProcessName,
                OperationName = filter.OperationName,
                PORNo = filter.PORNo,
                QCName = filter.QCName,
                UOM = filter.UOM,
                Start = filter.Start,
                End = filter.End,
                ArticleCode = filter.ArticleCode,
                ArticleName = filter.ArticleName,
                OperationCode = filter.OperationCode,
                OperationId = filter.OperationId,
                WFXArticleId = filter.WFXArticleId,
                BatchNo = filter.BatchNo,
                JobOrderNo = filter.JobOrderNo,

                IsActive = filter.IsActive,
            }));
        }

        // GET: api/v1/<controller>
        [HttpGet("FPPOOutputList")]
        public async Task<IActionResult> GetFPPOOutputToDetails([FromQuery] FPPOOutputToDetailsParameter filter)
        {
            return Ok(await Mediator.Send(new GetFPPOOutputToDetailsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,

                OCNo = filter.OCNo,
                FPPONo = filter.FPPONo,
                ArticleName = filter.ArticleName,
                BatchNo = filter.BatchNo,
                JobOrderNo = filter.JobOrderNo,
                PlannedQty = filter.PlannedQty,
                MadeQty = filter.MadeQty,
                BalanceQty = filter.BalanceQty,
                Size = filter.Size,
                Color = filter.Color,

                IsActive = filter.IsActive,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFPPOOutputQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateFPPOOutputCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateFPPOOutputCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFPPOOutputCommand { Id = id }));
        }
    }
}
