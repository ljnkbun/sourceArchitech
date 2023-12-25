using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Grades;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetGradesRequestConsumer : IConsumer<GetGradesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetGradesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetGradesRequest> context)
        {
            Log.Warning($"GetGradesRequestConsumer: request={context.Message.ToJson()}");

            var grades = await _mediator.Send(new GetGradesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (grades?.Data == null) await context.RespondAsync(null);
            var response = new GetGradesResponse
            {
                Data = grades.Data.Select(x => new GetGradeByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetGradesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}