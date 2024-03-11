using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Processes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetProcessByIdRequestConsumer : IConsumer<GetProcessByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetProcessByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetProcessByIdRequest> context)
        {
            Log.Warning($"GetGetProcessByIdRequestConsumer: request={context.Message.ToJson()}");

            var processLibRes = await _mediator.Send(new GetProcessQuery() { Id = context.Message.Id });
            if (processLibRes?.Data == null) await context.RespondAsync(null);
            var response = new GetProcessByIdResponse
            {
                Id = processLibRes.Data.Id,
                Code = processLibRes.Data.Code,
                Name = processLibRes.Data.Name,
                ProductGroupId = processLibRes.Data.ProductGroupId,
                CategoryId = processLibRes.Data.CategoryId,
                WFXProcessId = processLibRes.Data.WFXProcessId,
                SubCategoryGroupId = processLibRes.Data.SubCategoryGroupId,
                SubCategoryId = processLibRes.Data.SubCategoryId,
                LineIds = processLibRes.Data.Lines.Select(x => x.Id).ToList(),
                MachineIds = processLibRes.Data.Machines.Select(x => x.Id).ToList(),
                IsActive = processLibRes.Data.IsActive
            };
            Log.Information($"GetGetProcessByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}