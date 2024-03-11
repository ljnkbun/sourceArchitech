using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.WeavingOperationInputArticles;
using Shopfloor.IED.Application.Parameters.WeavingOperationInputArticles;
using Shopfloor.IED.Application.Query.WeavingOperationInputArticles;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeavingOperationInputArticleController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeavingOperationInputArticleParameter filter)
        {
            return Ok(await Mediator.Send(new GetWeavingOperationInputArticlesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                ArticleCode = filter.ArticleCode,
                ArticleName = filter.ArticleName,
                WFXArticleId = filter.WFXArticleId,
                WeavingOperationId = filter.WeavingOperationId,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWeavingOperationInputArticleQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWeavingOperationInputArticleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateWeavingOperationInputArticleCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWeavingOperationInputArticleCommand { Id = id }));
        }
    }
}