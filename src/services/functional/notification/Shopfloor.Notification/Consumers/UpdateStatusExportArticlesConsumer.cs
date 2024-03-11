using MassTransit;
using Microsoft.AspNetCore.SignalR.Client;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Message;

namespace Shopfloor.Notification.Consumers
{
    public class UpdateStatusExportArticlesConsumer : IConsumer<UpdateStatusExportArticlesMessage>
    {
        private readonly ILogger<UpdateStatusExportArticlesConsumer> _logger;
        private readonly HubConnection _hubConnection;
        public UpdateStatusExportArticlesConsumer(ILogger<UpdateStatusExportArticlesConsumer> logger,
            IConfiguration configuration)
        {
            _logger = logger;

            var domainUrl = configuration["DomainUrl"];
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
            {
                domainUrl = Environment.GetEnvironmentVariable("DomainUrl");
            }
            _hubConnection = new HubConnectionBuilder()
                .WithUrl($"{domainUrl}/UpdateStatusExportHub")
                .Build();
        }
        public async Task Consume(ConsumeContext<UpdateStatusExportArticlesMessage> context)
        {
            _logger.LogWarning($"UpdateStatusExportArticlesConsumer: request={context.Message.ToJson()}");

            try
            {
                await _hubConnection.StartAsync();
                await _hubConnection.SendAsync("RaiseChangeStatusExportArticles", context.Message);
                await _hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

            _logger.LogInformation($"UpdateStatusExportArticleConsumer successed.");
        }
    }
}