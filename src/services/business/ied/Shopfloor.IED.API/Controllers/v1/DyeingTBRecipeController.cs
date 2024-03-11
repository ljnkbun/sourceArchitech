using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DyeingTBRecipes;
using Shopfloor.IED.Application.Parameters.DyeingTBRecipes;
using Shopfloor.IED.Application.Query.DyeingTBRecipes;

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
                TBRecipeName = filter.TBRecipeName,
                Buyer = filter.Buyer,
                BuyerRef = filter.BuyerRef,
                GarmentStyleRef = filter.GarmentStyleRef,
                ExpectedDate = filter.ExpectedDate,
                Color = filter.Color,
                Concentration = filter.Concentration,
                VersionQty = filter.VersionQty,
                Status = filter.Status,
                ApproveVersionIndex = filter.ApproveVersionIndex,
                ApproveDate = filter.ApproveDate,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDyeingTBRecipeQuery { Id = id }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("color")]
        public async Task<IActionResult> GetColor(int dyeingTBMaterialColorId)
        {
            return Ok(await Mediator.Send(new GetDyeingTBRecipeByColorIdQuery { DyeingTBMaterialColorId = dyeingTBMaterialColorId }));
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

        // PUT api/v1/<controller>/5
        [HttpPut("approve")]
        public async Task<IActionResult> ApproveVersion(ApproveVersionDyeingTBRecipeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDyeingTBRecipeCommand { Id = id }));
        }


        [HttpGet("ExportExcel")]
        public async Task<IActionResult> ExportExcel(int id)
        {
            return await Mediator.Send(new ExportBeakerTestQuery { Id = id });
        }
    }
}