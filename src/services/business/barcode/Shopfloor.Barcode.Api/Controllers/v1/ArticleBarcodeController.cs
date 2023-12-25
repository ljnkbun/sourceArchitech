using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.ArticleBarcodes;
using Shopfloor.Barcode.Application.Command.BarcodeLocations;
using Shopfloor.Barcode.Application.Parameters.ArticleBarcodes;
using Shopfloor.Barcode.Application.Query.ArticleBarcodes;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ArticleBarcodeController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ArticleBarcodeParameter filter)
        {
            return Ok(await Mediator.Send(new GetArticleBarcodesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                CurrentLocationId = filter.CurrentLocationId,
                Barcode = filter.Barcode,
                ParentId = filter.ParentId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetArticleBarcodeQuery { Id = id }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("GetByBarcode/{barcode}")]
        public async Task<IActionResult> GetByBarcode(string barcode)
        {
            return Ok(await Mediator.Send(new GetArticleBarcodeByBarcodeQuery { Barcode = barcode }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateArticleBarcodeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateArticleBarcodeCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteArticleBarcodeCommand { Id = id }));
        }

        [HttpPost("location")]
        public async Task<IActionResult> UpdateArticleBarcodeLocation(UpdateArticleLocationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("split")]
        public async Task<IActionResult> Split(SplitArticleBarcodeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPost("merge")]
        public async Task<IActionResult> Merge(MergeArticleBarcodeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
