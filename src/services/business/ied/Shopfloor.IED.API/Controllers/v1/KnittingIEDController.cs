using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.KnittingIEDs;
using Shopfloor.IED.Application.Parameters.KnittingIEDs;
using Shopfloor.IED.Application.Query.KnittingIEDs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class KnittingIEDController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] KnittingIEDParameter filter)
        {
            return Ok(await Mediator.Send(new GetKnittingIEDsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                RequestNo = filter.RequestNo,
                RequestArticleOutputId = filter.RequestArticleOutputId,
                WFXArticleId = filter.WFXArticleId, 
                ArticleCode = filter.ArticleCode,
                ArticleName = filter.ArticleName,
                ProductGroup = filter.ProductGroup,
                SubCategory = filter.SubCategory,
                Buyer = filter.Buyer,
                Remark = filter.Remark,
                Status = filter.Status,
                RejectReason = filter.RejectReason,
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
            return Ok(await Mediator.Send(new GetKnittingIEDQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateKnittingIEDCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateKnittingIEDCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteKnittingIEDCommand { Id = id }));
        }
    }
}
