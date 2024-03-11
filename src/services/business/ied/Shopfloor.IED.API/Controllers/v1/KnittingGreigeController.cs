using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.KnittingGreiges;
using Shopfloor.IED.Application.Parameters.KnittingGreiges;
using Shopfloor.IED.Application.Query.KnittingGreiges;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class KnittingGreigeController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] KnittingGreigeParameter filter)
        {
            return Ok(await Mediator.Send(new GetKnittingGreigesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                KnittingIEDId = filter.KnittingIEDId,
                KnittingBodyTypeId = filter.KnittingBodyTypeId,
                KnittingTypeId = filter.KnittingTypeId,
                Width = filter.Width,
                WidthLossRate = filter.WidthLossRate,
                WeightGM = filter.WeightGM,
                WeightGMLossRate = filter.WeightGMLossRate,
                VerticalDensity = filter.VerticalDensity,
                VerticalDensityLossRate = filter.VerticalDensityLossRate,
                HorizontalDensity = filter.HorizontalDensity,
                HorizontalDensityLossRate = filter.HorizontalDensityLossRate,
                WrapShrinkage = filter.WrapShrinkage,
                KnittingShrinkageId = filter.KnittingShrinkageId,
                WeftShrinkage = filter.WeftShrinkage,
                Gauge = filter.Gauge,
                Feeder = filter.Feeder,
                UsedFeeder = filter.UsedFeeder,
                Needle = filter.Needle,
                RappoLength = filter.RappoLength,
                MachineDiameter = filter.MachineDiameter,
                WeightKg = filter.WeightKg,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetKnittingGreigeQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateKnittingGreigeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateKnittingGreigeCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteKnittingGreigeCommand { Id = id }));
        }
    }
}
