using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingOperationWFXs;
using Shopfloor.IED.Application.Parameters.SewingOperationWFXs;
using Shopfloor.IED.Application.Query.SewingOperationWFXs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingOperationWFXController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingOperationWFXParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingOperationWFXsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                RequestDivisionProcessId = filter.RequestDivisionProcessId,
                CurrentVersionId = filter.CurrentVersionId,
                WFXProcessCode = filter.WFXProcessCode,
                WFXProcessName = filter.WFXProcessName,
                Buyer = filter.Buyer,
                ProductGroup = filter.ProductGroup,
                ProductSubCategory = filter.ProductSubCategory,
                ArticleId = filter.ArticleId,
                ArticleCode = filter.ArticleCode,
                ArticleName = filter.ArticleName,
                Description = filter.Description,
                Comments = filter.Comments,
                Status = filter.Status,
                Deleted = filter.Deleted,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5/version/1
        [HttpGet("{id}/version/{versionNumber}")]
        public async Task<IActionResult> Get(int id, int versionNumber)
        {
            return Ok(await Mediator.Send(new GetSewingOperationWFXQuery()
            {
                Id = id,
                Version = versionNumber
            }));
        }

        // GET api/v1/<controller>/5/version
        [HttpGet("{id}/version")]
        public async Task<IActionResult> GetVersions(int id)
        {
            return Ok(await Mediator.Send(new GetVersionsQuery()
            {
                SewingOperationWFXId = id
            }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingOperationWFXCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/v1/<controller>/version
        [HttpPost("version")]
        public async Task<IActionResult> CreateVersion(CreateVersionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSewingOperationWFXCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingOperationWFXCommand { Id = id }));
        }
    }
}
