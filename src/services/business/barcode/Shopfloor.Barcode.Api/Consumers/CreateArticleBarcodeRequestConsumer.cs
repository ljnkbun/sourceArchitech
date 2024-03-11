using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Barcode.Application.Command.ArticleBarcodes;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Barcodes;
using Shopfloor.EventBus.Models.Responses.Barcodes;

namespace Shopfloor.Barcode.Api.Consumers.Requests
{
    public class CreateArticleBarcodeRequestConsumer : IConsumer<CreateArticleBarcodeRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public CreateArticleBarcodeRequestConsumer(IMediator mediator
            )
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<CreateArticleBarcodeRequest> context)
        {
            Log.Warning($"GetImportSyncRequestConsumer: request={context.Message.ToJson()}");

            var ImportSync = await _mediator.Send(new CreateArticleBarcodeCommand()
            {
                Barcode = context.Message.Barcode,
                ArticleName = context.Message.ArticleName,
                ArticleCode = context.Message.ArticleCode,
                Quantity = context.Message.Quantity,
                RemainQuantity = context.Message.RemainQuantity,
                UOM = context.Message.UOM,
                Shade = context.Message.Shade,
                OC = context.Message.OC,
                Color = context.Message.Color,
                Size = context.Message.Size,
                NumberOfCone = context.Message.NumberOfCone,
                WeightPerCone = context.Message.WeightPerCone,
                Location = context.Message.Location,
                Site = context.Message.Site,
                Category = context.Message.Category,
                SubCategory = context.Message.SubCategory,
                GroupCode = context.Message.GroupCode,
                Note = context.Message.Note,
                CurrentLocationId = context.Message.CurrentLocationId,
                PreLocationId = context.Message.PreLocationId,

            });
            var response = new CreateArticleBarcodeResponse()
            {
                Id = ImportSync.Data
            };

            Log.Information($"GetGDIRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }

}