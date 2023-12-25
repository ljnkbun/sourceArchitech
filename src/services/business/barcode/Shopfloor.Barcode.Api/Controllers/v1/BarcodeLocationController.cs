using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.BarcodeLocations;
using Shopfloor.Barcode.Application.Parameters.BarcodeLocations;
using Shopfloor.Barcode.Application.Query.BarcodeLocations;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BarcodeLocationController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BarcodeLocationParameter filter)
        {
            return Ok(await Mediator.Send(new GetBarcodeLocationsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                LocationId = filter.LocationId,
                ArticleBarcodeId = filter.ArticleBarcodeId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetBarcodeLocationQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateBarcodeLocationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateBarcodeLocationCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteBarcodeLocationCommand { Id = id }));
        }
    }
}
