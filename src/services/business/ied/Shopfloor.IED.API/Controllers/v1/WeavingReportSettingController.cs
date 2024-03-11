using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.WeavingReportSettings;
using Shopfloor.IED.Application.Parameters.WeavingReportSettings;
using Shopfloor.IED.Application.Query.WeavingReportSettings;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeavingReportSettingController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeavingReportSettingParameter filter)
        {
            return Ok(await Mediator.Send(new GetWeavingReportSettingsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Locked = filter.Locked,
                Repeat = filter.Repeat,
                NumberOfSplit = filter.NumberOfSplit,
                WeavingIEDId = filter.WeavingIEDId,
                SettingType = filter.SettingType,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWeavingReportSettingQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWeavingReportSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateWeavingReportSettingCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("lock/{id}")]
        public async Task<IActionResult> PutLock(int id)
        {
            return Ok(await Mediator.Send(new LockWeavingReportSettingCommand { Id = id }));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWeavingReportSettingCommand { Id = id }));
        }
    }
}