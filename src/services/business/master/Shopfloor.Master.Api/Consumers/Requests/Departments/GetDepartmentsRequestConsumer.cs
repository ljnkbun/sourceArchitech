using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Departments;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetDepartmentsRequestConsumer : IConsumer<GetDepartmentsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetDepartmentsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetDepartmentsRequest> context)
        {
            Log.Warning($"GetDepartmentsRequestConsumer: request={context.Message.ToJson()}");

            var departments = await _mediator.Send(new GetDepartmentsQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                DivisionId = context.Message.DivisionId,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (departments?.Data == null) await context.RespondAsync(null);
            var response = new GetDepartmentsResponse
            {
                Data = departments.Data.Select(x => new GetDepartmentByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    DivisionId = x.DivisionId,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetDepartmentsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}