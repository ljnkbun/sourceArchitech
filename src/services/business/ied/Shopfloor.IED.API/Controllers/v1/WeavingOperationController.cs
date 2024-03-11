using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.WeavingOperations;
using Shopfloor.IED.Application.Parameters.WeavingOperations;
using Shopfloor.IED.Application.Query.WeavingOperations;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeavingOperationController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeavingOperationParameter filter)
        {
            return Ok(await Mediator.Send(new GetWeavingOperationsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                ArticleCode = filter.ArticleCode,
                OperationId = filter.OperationId,
                ArticleName = filter.ArticleName,
                LineNumber = filter.LineNumber,
                MachineType = filter.MachineType,
                Operation = filter.Operation,
                WFXArticleId = filter.WFXArticleId,
                WeavingRoutingId = filter.WeavingRoutingId,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWeavingOperationQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWeavingOperationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateWeavingOperationCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWeavingOperationCommand { Id = id }));
        }
    }
}