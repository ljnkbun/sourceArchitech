using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DyeingIEDs;
using Shopfloor.IED.Application.Parameters.DyeingIEDs;
using Shopfloor.IED.Application.Query.DyeingIEDs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DyeingIEDController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DyeingIEDParameter filter)
        {
            return Ok(await Mediator.Send(new GetDyeingIEDsQuery()
            {
                RequestArticleOutputId = filter.RequestArticleOutputId,
                WFXArticleId = filter.WFXArticleId,
                ArticleCode = filter.ArticleCode,
                ArticleName = filter.ArticleName,
                ProductGroup = filter.ProductGroup,
                RequestNo = filter.RequestNo,
                RequestTypeId = filter.RequestTypeId,
                SubCategory = filter.SubCategory,
                Buyer = filter.Buyer,
                Color = filter.Color,
                ColorRef = filter.ColorRef,
                RecipeId = filter.RecipeId,
                Status = filter.Status,
                Comment = filter.Comment,
                RejectReason = filter.RejectReason,
                TCFNo = filter.TCFNo,
                WFXInputMaterialId = filter.WFXInputMaterialId,
                InputMaterialName = filter.InputMaterialName,
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
            return Ok(await Mediator.Send(new GetDyeingIEDQuery { Id = id }));
        }

        // GET: api/v1/<controller>
        [HttpGet("search")]
        public async Task<IActionResult> GetSearchIED([FromQuery] SearchDyeingIEDParameter filter)
        {
            return Ok(await Mediator.Send(new GetSearchDyeingIEDsQuery
            {
                Status = filter.Status,
                RequestNo = filter.RequestNo,
                RequestType = filter.RequestType,
                ArticleName = filter.ArticleName,
                ProductGroup = filter.ProductGroup,
                SubCategory = filter.SubCategory,
                Buyer = filter.Buyer,
                ExpectedDate = filter.ExpectedDate,
                RecipeNo = filter.RecipeNo,
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

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDyeingIEDCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDyeingIEDCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            return Ok(await Mediator.Send(new SoftDeleteDyeingIEDCommand { Id = id }));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDyeingIEDCommand { Id = id }));
        }
    }
}