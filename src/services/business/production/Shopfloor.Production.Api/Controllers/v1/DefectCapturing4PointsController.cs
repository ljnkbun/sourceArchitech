using Microsoft.AspNetCore.Mvc;
using Shopfloor.Production.Application.Command.DefectCapturing4Pointss;
using Shopfloor.Production.Application.Command.Measurements;
using Shopfloor.Production.Application.Parameters.DefectCapturing4Pointss;
using Shopfloor.Production.Application.Parameters.Measurements;
using Shopfloor.Production.Application.Query.DefectCapturing4Pointss;
using Shopfloor.Production.Application.Query.Measurements;

namespace Shopfloor.Production.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DefectCapturing4PointsController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DefectCapturing4PointsParameter filter)
        {
            return Ok(await Mediator.Send(new GetDefectCapturing4PointssQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,

                ProductionOutputId = filter.ProductionOutputId,
                QCDefectId = filter.QCDefectId,
                MinorOne = filter.MinorOne,
                MinorTwo = filter.MinorTwo,
                MinorThree = filter.MinorThree,
                MinorFour = filter.MinorFour,
                MajorOne = filter.MajorOne,
                MajorTwo = filter.MajorTwo,
                MajorThree = filter.MajorThree,
                MajorFour = filter.MajorFour,
                DefectQtyOne = filter.DefectQtyOne,
                DefectQtyTwo = filter.DefectQtyTwo,
                DefectQtyThree = filter.DefectQtyThree,
                DefectQtyFour = filter.DefectQtyFour,
                ParentId = filter.ParentId,
                RootCauseIds = filter.RootCauseIds,
                PersonInChargeIds = filter.PersonInChargeIds,
                CorrectActionIds = filter.CorrectActionIds,
                IsLongError = filter.IsLongError,
                LongErrorFrom = filter.LongErrorFrom,
                LongErrorTo = filter.LongErrorTo,
                ErrorCode = filter.ErrorCode,
                ErrorName = filter.ErrorName,
                TimelineId = filter.TimelineId,

                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDefectCapturing4PointsQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDefectCapturing4PointsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDefectCapturing4PointsCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDefectCapturing4PointsCommand { Id = id }));
        }
    }
}
