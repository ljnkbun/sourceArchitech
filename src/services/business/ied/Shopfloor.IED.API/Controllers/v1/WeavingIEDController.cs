using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.WeavingIEDs;
using Shopfloor.IED.Application.Parameters.WeavingIEDs;
using Shopfloor.IED.Application.Query.WeavingIEDs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeavingIEDController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeavingIEDParameter filter)
        {
            return Ok(await Mediator.Send(new GetWeavingIEDsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                RequestArticleOutputId = filter.RequestArticleOutputId,
                WFXArticleId = filter.WFXArticleId,
                RequestNo = filter.RequestNo,
                RequestTypeId = filter.RequestTypeId,
                ArticleCode = filter.ArticleCode,
                ArticleName = filter.ArticleName,
                ProductGroup = filter.ProductGroup,
                SubCategory = filter.SubCategory,
                Buyer = filter.Buyer,
                Comment = filter.Comment,
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
            return Ok(await Mediator.Send(new GetWeavingIEDQuery { Id = id }));
        }  
        
        // GET api/v1/<controller>/5
        [HttpGet("report/{id}")]
        public async Task<IActionResult> GetReport(int id)
        {
            return Ok(await Mediator.Send(new GetWeavingIEDReportsQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWeavingIEDCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateWeavingIEDCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWeavingIEDCommand { Id = id }));
        }
    }
}
