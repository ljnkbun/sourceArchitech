using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Departments;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetDepartmentByIdRequestConsumer : IConsumer<GetDepartmentByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetDepartmentByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetDepartmentByIdRequest> context)
        {
            Log.Warning($"GetDepartmentByIdRequestConsumer: request={context.Message.ToJson()}");

            var departments = await _mediator.Send(new GetDepartmentQuery() { Id = context.Message.Id });
            if (departments?.Data == null) await context.RespondAsync(null);
            var response = new GetDepartmentByIdResponse
            {
                Id = departments.Data.Id,
                Code = departments.Data.Code,
                Name = departments.Data.Name,
                DivisionId = departments.Data.DivisionId,
                IsActive = departments.Data.IsActive
            };
            Log.Information($"GetDepartmentByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}