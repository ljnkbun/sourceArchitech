using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.AppVersions;
using Shopfloor.Barcode.Application.Parameters.AppVersions;
using Shopfloor.Barcode.Application.Query.AppVersions;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AppVersionController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AppVersionParameter filter)
        {
            return Ok(await Mediator.Send(new GetAppVersionsQuery()
            {
                Version = filter.Version,
                Name = filter.Name,
                FileId = filter.FileId,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("lastversion")]
        public async Task<IActionResult> GetLastVersion()
        {
            return Ok(await Mediator.Send(new GetLastVersionQuery()));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateAppVersionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}