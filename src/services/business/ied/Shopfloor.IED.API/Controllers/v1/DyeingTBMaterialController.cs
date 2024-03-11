using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DyeingTBMaterials;
using Shopfloor.IED.Application.Parameters.DyeingTBMaterials;
using Shopfloor.IED.Application.Query.DyeingTBMaterials;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DyeingTBMaterialController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DyeingTBMaterialParameter filter)
        {
            return Ok(await Mediator.Send(new GetDyeingTBMaterialsQuery()
            {
                DyeingTBRequestId = filter.DyeingTBRequestId,
                WFXArticleId = filter.WFXArticleId,
                ArticleCode = filter.ArticleCode,
                ArticleName = filter.ArticleName,
                MaterialType = filter.MaterialType,
                FabricContent = filter.FabricContent,
                FabricStyleRef = filter.FabricStyleRef,
                Lights = filter.Lights,
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
            return Ok(await Mediator.Send(new GetDyeingTBMaterialQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDyeingTBMaterialCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDyeingTBMaterialCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDyeingTBMaterialCommand { Id = id }));
        }
    }
}