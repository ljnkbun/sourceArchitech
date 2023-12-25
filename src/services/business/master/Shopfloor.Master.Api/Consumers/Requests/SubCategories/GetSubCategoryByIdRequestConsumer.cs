using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SubCategories;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSubCategoryByIdRequestConsumer : IConsumer<GetSubCategoryByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSubCategoryByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSubCategoryByIdRequest> context)
        {
            Log.Warning($"GetSubCategoryByIdRequestConsumer: request={context.Message.ToJson()}");

            var subCategories = await _mediator.Send(new GetSubCategoryQuery() { Id = context.Message.Id });
            if (subCategories?.Data == null) await context.RespondAsync(null);
            var response = new GetSubCategoryByIdResponse
            {
                Id = subCategories.Data.Id,
                Code = subCategories.Data.Code,
                Name = subCategories.Data.Name,
                SubCategoryGroupId = subCategories.Data.SubCategoryGroupId,
                ExciseTarrifNo = subCategories.Data.ExciseTarrifNo,
                PackagingUnit = subCategories.Data.PackagingUnit,
                ByPassPriceList = subCategories.Data.ByPassPriceList,
                DefaultInactiveIndent = subCategories.Data.DefaultInactiveIndent,
                ProductGroupId = subCategories.Data.ProductGroupId,
                IsActive = subCategories.Data.IsActive
            };
            Log.Information($"GetSubCategoryByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}