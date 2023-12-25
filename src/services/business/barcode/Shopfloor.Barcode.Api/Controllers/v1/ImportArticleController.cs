using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.ImportArticles;
using Shopfloor.Barcode.Application.Parameters.ImportArticles;
using Shopfloor.Barcode.Application.Query.ImportArticles;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    public class ImportArticleController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ImportArticleParameter filter)
        {
            return Ok(await Mediator.Send(new GetImportArticlesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                ArticleCode = filter.ArticleCode,
                ArticleName = filter.ArticleName,
                GDNNumber = filter.GDNNumber,
                FromSite= filter.FromSite,
                ToSite=filter.ToSite,
                SupplierName = filter.SupplierName,
                OrderRefNum = filter.OrderRefNum,
                ColorName = filter.ColorName,
                ColorCode = filter.ColorCode,
                SizeCode = filter.SizeCode,
                UOM = filter.UOM,
                Units = filter.Units,
                OCNum = filter.OCNum,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
            })); ; ;
        }
        [HttpGet("Multi{ids}")]
        public async Task<IActionResult> Get(string ids)
        {
            return Ok(await Mediator.Send(new GetMultiImportArticleQuery { Ids = ids }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetImportArticleQuery { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateImportArticleCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateImportArticleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteImportArticleCommand { Id = id }));
        }
    }
}
