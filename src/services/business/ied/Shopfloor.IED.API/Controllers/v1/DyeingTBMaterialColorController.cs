using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DyeingTBMaterialColors;
using Shopfloor.IED.Application.Parameters.DyeingTBMaterialColors;
using Shopfloor.IED.Application.Query.DyeingTBMaterialColors;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DyeingTBMaterialColorController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DyeingTBMaterialColorParameter filter)
        {
            return Ok(await Mediator.Send(new GetDyeingTBMaterialColorsQuery()
            {
                DyeingTBMaterialId = filter.DyeingTBMaterialId,
                Color = filter.Color,
                Pantone = filter.Pantone,
                Status = filter.Status,
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

        // GET: api/v1/<controller>
        [HttpGet("search")]
        public async Task<IActionResult> Get([FromQuery] DyeingTBMaterialColorSearchParameter filter)
        {
            return Ok(await Mediator.Send(new GetDyeingTBMaterialColorSearchesQuery
            {
                RequestNo = filter.RequestNo,
                ArticleCode = filter.ArticleCode,
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
            return Ok(await Mediator.Send(new GetDyeingTBMaterialColorQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDyeingTBMaterialColorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDyeingTBMaterialColorCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDyeingTBMaterialColorCommand { Id = id }));
        }
    }
}