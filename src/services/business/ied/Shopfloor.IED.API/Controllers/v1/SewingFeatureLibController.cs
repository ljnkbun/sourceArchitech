using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingFeatureLibs;
using Shopfloor.IED.Application.Parameters.SewingFeatureLibs;
using Shopfloor.IED.Application.Query.SewingFeatureLibs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingFeatureLibController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingFeatureLibParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingFeatureLibsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Code = filter.Code,
                Name = filter.Name,
                Description = filter.Description,
                BuyerCode = filter.BuyerCode,
                BuyerName = filter.BuyerName,
                SubCategoryCode = filter.SubCategoryCode,
                SubCategoryName = filter.SubCategoryName,
                SewingComponentId = filter.SewingComponentId,
                LabourCost = filter.LabourCost,
                AllowedTime = filter.AllowedTime,
                TotalSMV = filter.TotalSMV,
                FolderTreeId = filter.FolderTreeId,
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
            return Ok(await Mediator.Send(new GetSewingFeatureLibQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingFeatureLibCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSewingFeatureLibCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingFeatureLibCommand { Id = id }));
        }
    }
}
