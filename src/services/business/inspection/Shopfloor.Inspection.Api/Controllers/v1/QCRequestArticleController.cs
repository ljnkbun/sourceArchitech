using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.QCRequestArticles;
using Shopfloor.Inspection.Application.Parameters.QCRequestArticles;
using Shopfloor.Inspection.Application.Query.QCRequestArticles;
using System.Drawing.Imaging;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class QCRequestArticleController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QCRequestArticleParameter filter)
        {
            return Ok(await Mediator.Send(new GetQCRequestArticlesQuery()
            {
                QCTypeId = filter.QCTypeId,
                QCRequestNo = filter.QCRequestNo,
                QCRequestId = filter.QCRequestId,
				ArticleCode = filter.ArticleCode,
				ArticleName = filter.ArticleName,
				Shade = filter.Shade,
				Lot = filter.Lot,
				StyleNo = filter.StyleNo,
				StyleName = filter.StyleName,
                ColorCode = filter.ColorCode,
                ColorName = filter.ColorName,
                SizeCode = filter.SizeCode,
                SizeName = filter.SizeName,
                QCReleasedQty = filter.QCReleasedQty,
                GRNQty = filter.GRNQty,
                Season = filter.Season,
				Buyer = filter.Buyer,
				FPONo = filter.FPONo,
				Location = filter.Location,
				UOM = filter.UOM,
				OCNo = filter.OCNo,
				GRNNo = filter.GRNNo,
				PONo = filter.PONo,
				GRNDate = filter.GRNDate,
				RequestedQty = filter.RequestedQty,
                JobOrderNo = filter.JobOrderNo,
                BatchNo = filter.BatchNo,
                Line = filter.Line,
                Machine = filter.Machine,
                PlannedQty = filter.PlannedQty,
                MadeQty = filter.MadeQty,
                BalanceQty = filter.BalanceQty,
                WeightKg = filter.WeightKg,
                WidghtKg = filter.WidghtKg,
                Length = filter.Length,
                RollQty = filter.RollQty,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetQCRequestArticleQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateQCRequestArticleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateQCRequestArticleCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteQCRequestArticleCommand { Id = id }));
        }
      
    }
}
