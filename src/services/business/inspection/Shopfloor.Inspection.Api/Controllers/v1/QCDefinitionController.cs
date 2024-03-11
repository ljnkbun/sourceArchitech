using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.QCDefinitions;
using Shopfloor.Inspection.Application.Parameters.QCDefinitions;
using Shopfloor.Inspection.Application.Query.QCDefinitions;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class QCDefinitionController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QCDefinitionParameter filter)
        {
            return Ok(await Mediator.Send(new GetQCDefinitionsQuery()
            {
                Buyer = filter.Buyer,
				Category = filter.Category,
				AcceptanceValue = filter.AcceptanceValue,
				SamplingId = filter.SamplingId,
				ConversionId = filter.ConversionId,
                QCTypeId = filter.QCTypeId,
                PercentQC = filter.PercentQC,
                PercentAcceptance = filter.PercentAcceptance,
                FixedQty = filter.FixedQty,
                AcceptanceQty = filter.AcceptanceQty,
                Quantity = filter.Quantity,
                AQLVersionId = filter.AQLVersionId,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Code = filter.Code,
                Name = filter.Name,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetQCDefinitionQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateQCDefinitionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateQCDefinitionCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteQCDefinitionCommand { Id = id }));
        }
    }
}
