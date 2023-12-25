﻿using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.FiberTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetFiberTypesRequestConsumer : IConsumer<GetFiberTypesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetFiberTypesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetFiberTypesRequest> context)
        {
            Log.Warning($"GetFiberTypesRequestConsumer: request={context.Message.ToJson()}");

            var fiberTypes = await _mediator.Send(new GetFiberTypesQuery()
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
            if (fiberTypes?.Data == null) await context.RespondAsync(null);
            var response = new GetFiberTypesResponse
            {
                Data = fiberTypes.Data.Select(x => new GetFiberTypeByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetFiberTypesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}