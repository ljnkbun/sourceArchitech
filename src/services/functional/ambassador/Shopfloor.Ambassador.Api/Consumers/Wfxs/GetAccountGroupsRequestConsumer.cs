using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetWfxMasterDataRequestConsumer : IConsumer<GetWfxMasterDataRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetWfxMasterDataRequestConsumer(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetWfxMasterDataRequest> context)
        {
            Log.Warning($"GetMasterDataRequestConsumer: request={context.Message.ToJson()}");

            var masterData = await _mediator.Send(new GetWfxMasterDataQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                MetaDataFor = context.Message.MetaDataFor,
            });
            if (masterData?.Data == null) await context.RespondAsync(null);
            var response = new GetWfxMasterDataResponse
            {
                Data = _mapper.Map<List<WfxMasterDataDto>>(masterData.Data)
            };
            Log.Information($"GetMasterDataRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}