using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.Locations;
using Shopfloor.Barcode.Application.Parameters.Locations;
using Shopfloor.Barcode.Application.Query.ImportDetails;
using Shopfloor.Barcode.Application.Query.Locations;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class LocationController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] LocationParameter filter)
        {
            return Ok(await Mediator.Send(new GetLocationsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                OrderBy = filter.OrderBy,
                Code = filter.Code,
                Name = filter.Name,
                ParentLocationId = filter.ParentLocationId,
                Barcode = filter.Barcode,
                LevelLocation = filter.LevelLocation,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetLocationQuery { Id = id }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("GetByBarcode")]
        public async Task<IActionResult> GetByBarcode(string barcode)
        {
            return Ok(await Mediator.Send(new GetLocationByBarcodeQuery { Barcode = barcode }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateLocationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateLocationCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteLocationCommand { Id = id }));
        }

        [HttpPost("Print")]
        public async Task<IActionResult> Print(PrintLocationsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
