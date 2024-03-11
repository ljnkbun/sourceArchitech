using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.Requests;
using Shopfloor.IED.Application.Command.SewingIEDs;
using Shopfloor.IED.Application.Parameters.SewingIEDs;
using Shopfloor.IED.Application.Query.SewingIEDs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingIEDController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingIEDParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingIEDsQuery()
            {
                RequestNo = filter.RequestNo,
                RequestArticleOutputId = filter.RequestArticleOutputId,
                WFXArticleId = filter.WFXArticleId,
                ArticleCode = filter.ArticleCode,
                ArticleName = filter.ArticleName,
                Buyer = filter.Buyer,
                StyleRef = filter.StyleRef,
                ProductGroup = filter.ProductGroup,
                SubCategory = filter.SubCategory,
                Description = filter.Description,
                SMV = filter.SMV,
                AllowedTime = filter.AllowedTime,
                FactoryTime = filter.FactoryTime,
                LabourCostOp = filter.LabourCostOp,
                LabourCostFactory = filter.LabourCostFactory,
                FactoryOverheadAgainstLabourPercent = filter.FactoryOverheadAgainstLabourPercent,
                LabourCostFactoryIncludingOverhead = filter.LabourCostFactoryIncludingOverhead,
                Comment = filter.Comment,
                AnalysisDate = filter.AnalysisDate,
                AnalysisUser = filter.AnalysisUser,
                Status = filter.Status,
                RejectReason = filter.RejectReason,
                Deleted = filter.Deleted,
                
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSewingIEDQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingIEDCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSewingIEDCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingIEDCommand { Id = id }));
        }
    }
}
