using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.StripFactories;
using Shopfloor.Planning.Application.Parameters.StripFactories;
using Shopfloor.Planning.Application.Query.StripFactories;
using Shopfloor.Planning.Application.Query.StripFactoryPors;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class StripFactoryController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] StripFactoryParameter filter)
        {
            return Ok(await Mediator.Send(new GetStripFactoriesQuery()
            {
                PlanningGroupFactoryId = filter.PlanningGroupFactoryId,
                ProcessId = filter.ProcessId,
                StartDate = filter.StartDate,
                EndDate = filter.EndDate,
                Quantity = filter.Quantity,
                PORId = filter.PORId,
                IsPlanning = filter.IsPlanning,
                PageSize = filter.PageSize,
                IsAllocated = filter.IsAllocated,
                ArticleName = filter.ArticleName,
                ArticleCode = filter.ArticleCode,
                Buyer = filter.Buyer,
                Category = filter.Category,
                SubCategory = filter.SubCategory,
                ProductGroup = filter.ProductGroup,
                JobOrderNo = filter.JobOrderNo,
                BatchNo = filter.BatchNo,
                OrderBy = filter.OrderBy,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
            }));
        }

        // GET: api/v1/<controller>
        [HttpGet("por")]
        public async Task<IActionResult> Get([FromQuery] GetStripFactoryPorsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetStripFactoryQuery { Id = id }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("articleCode/{articlecode}")]
        public async Task<IActionResult> GetByArticleCode(string articlecode)
        {
            return Ok(await Mediator.Send(new GetStripFactoryByArticleCodeQuery() { ArticleCode = articlecode }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateStripFactoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateStripFactoryCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPost("accept")]
        public async Task<IActionResult> Accept(AcceptStripFactoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPost("reject")]
        public async Task<IActionResult> Reject(RejectStripFactoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteStripFactoryCommand { Id = id }));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("range")]
        public async Task<IActionResult> Delete(DeleteStripFactoriesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/v1/<controller>
        [HttpPost("save")]
        public async Task<IActionResult> SaveStripFactories(SaveStripFactoriesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
