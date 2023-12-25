using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Grades;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetGradeByIdRequestConsumer : IConsumer<GetGradeByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetGradeByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetGradeByIdRequest> context)
        {
            Log.Warning($"GetGradeByIdRequestConsumer: request={context.Message.ToJson()}");

            var grades = await _mediator.Send(new GetGradeQuery() { Id = context.Message.Id });
            if (grades?.Data == null) await context.RespondAsync(null);
            var response = new GetGradeByIdResponse
            {
                Id = grades.Data.Id,
                Code = grades.Data.Code,
                Name = grades.Data.Name,
                IsActive = grades.Data.IsActive
            };
            Log.Information($"GetGradeByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}