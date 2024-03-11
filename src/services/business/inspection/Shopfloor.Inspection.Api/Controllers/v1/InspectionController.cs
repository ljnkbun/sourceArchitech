using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.Inspections;
using Shopfloor.Inspection.Application.Parameters.Inspections;
using Shopfloor.Inspection.Application.Query.Inpection100PointSyss;
using Shopfloor.Inspection.Application.Query.Inpection4PointSyss;
using Shopfloor.Inspection.Application.Query.InpectionTCStandards;
using Shopfloor.Inspection.Application.Query.Inspections;
using Shopfloor.Inspection.Application.Query.QCTypes;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InspectionController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InspectionParameter filter)
        {
            return Ok(await Mediator.Send(new GetInspectionsQuery()
            {
                InspectionDate = filter.InspectionDate,
                QCRequestArticleId = filter.QCRequestArticleId,
                DefaultResult = filter.DefaultResult,
                UserResult = filter.UserResult,
                MeasurementResult = filter.MeasurementResult,
                MeasurementQty = filter.MeasurementQty,
                InspectionQty = filter.InspectionQty,
                Reason = filter.Reason,
                Remark = filter.Remark,
                Line = filter.Line,
                TotalDefect = filter.TotalDefect,
                Stage = filter.Stage,
                CuttingTable = filter.CuttingTable,
                IsCreatedFromProduction = filter.IsCreatedFromProduction,
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
        public async Task<IActionResult> Get(int id, [FromQuery] string qcDefineCode)
        {
            var qcType = await Mediator.Send(new GetQCTypeByQCDefineCodeQuery { QcDefineCode = qcDefineCode });
            IActionResult actionResult = null;
            var qcScreenType = qcType.Data.QCScreenType;
            switch (qcScreenType)
            {
                case Domain.Enums.QCScreenType.Garment:
                    actionResult=Ok(await Mediator.Send(new GetInspectionQuery { Id = id }));
                    break;
                case Domain.Enums.QCScreenType.Fabric4Point:
                    actionResult=Ok(await Mediator.Send(new GetInpection4PointSysQuery { Id = id }));
                    break;
                case Domain.Enums.QCScreenType.Fabric100Point:
                    actionResult = Ok(await Mediator.Send(new GetInpection100PointSysQuery { Id = id }));
                    break;
                case Domain.Enums.QCScreenType.TCStandardFixed:
                case Domain.Enums.QCScreenType.TCStandardPercent:
                    actionResult = Ok(await Mediator.Send(new GetInpectionTCStandardQuery { Id = id }));
                    break;
                default:
                    actionResult =BadRequest();
                    break;
            }
            return actionResult;
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInspectionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateInspectionCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInspectionCommand { Id = id }));
        }
    }
}
