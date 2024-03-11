using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.WeavingDetailStructures;
using Shopfloor.IED.Application.Parameters.WeavingDetailStructures;
using Shopfloor.IED.Application.Query.WeavingDetailStructures;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeavingDetailStructureController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeavingDetailStructureParameter filter)
        {
            return Ok(await Mediator.Send(new GetWeavingDetailStructuresQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                WeavingIEDId = filter.WeavingIEDId,
                StructureType = filter.StructureType,
                LineNumber = filter.LineNumber,
                Denting = filter.Denting,
                DentSplit = filter.DentSplit,
                Total = filter.Total,
                Deleted = filter.Deleted,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWeavingDetailStructureQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWeavingDetailStructureCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateWeavingDetailStructureCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWeavingDetailStructureCommand { Id = id }));
        }
    }
}
