using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DyeingTBRecipes;
using Shopfloor.IED.Application.Parameters.DyeingTBRecipes;
using Shopfloor.IED.Application.Query.DyeingTBRecipes;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DyeingTBRecipeController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DyeingTBRecipeParameter filter)
        {
            return Ok(await Mediator.Send(new GetDyeingTBRecipesQuery()
            {
                DyeingTBMaterialColorId = filter.DyeingTBMaterialColorId,
                TBRecipeNo = filter.TBRecipeNo,
                TemplateId = filter.TemplateId,
                TemplateName = filter.TemplateName,
                TCFNo = filter.TCFNo,
                Comment = filter.Comment,
                Buyer = filter.Buyer,
                BuyerRef = filter.BuyerRef,
                GarmentStyleRef = filter.GarmentStyleRef,
                ExpectedDate = filter.ExpectedDate,
                Color = filter.Color,
                Concentration = filter.Concentration,
                VersionQty = filter.VersionQty,
                Status = filter.Status,
                ApproveVersionId = filter.ApproveVersionId,
                ApproveDate = filter.ApproveDate,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDyeingTBRecipeQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDyeingTBRecipeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDyeingTBRecipeCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDyeingTBRecipeCommand { Id = id }));
        }
    }
}