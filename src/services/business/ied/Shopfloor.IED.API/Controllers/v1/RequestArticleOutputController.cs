using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.RequestArticleOutputs;
using Shopfloor.IED.Application.Parameters.RequestArticleOutputs;
using Shopfloor.IED.Application.Query.RequestArticleOutputs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RequestArticleOutputController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestArticleOutputParameter filter)
        {
            return Ok(await Mediator.Send(new GetRequestArticleOutputsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                RequestDivisionProcessId = filter.RequestDivisionProcessId,
                ArticleId = filter.ArticleId,
                ArticleCode = filter.ArticleCode,
                ArticleName = filter.ArticleName,
                Color = filter.Color,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetRequestArticleOutputQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateRequestArticleOutputCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRequestArticleOutputCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRequestArticleOutputCommand { Id = id }));
        }
    }
}
