using MassTransit;
using Microsoft.AspNetCore.SignalR.Client;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Message;

namespace Shopfloor.Notification.Consumers
{
    public class UpdateStatusImportArticlesConsumer : IConsumer<UpdateStatusImportArticlesMessage>
    {
        private readonly ILogger<UpdateStatusImportArticlesConsumer> _logger;
        private readonly HubConnection _hubConnection;
        public UpdateStatusImportArticlesConsumer(ILogger<UpdateStatusImportArticlesConsumer> logger,
            IConfiguration configuration)
        {
            _logger = logger;

            var domainUrl = configuration["DomainUrl"];
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
            {
                domainUrl = Environment.GetEnvironmentVariable("DomainUrl");
            }
            _hubConnection = new HubConnectionBuilder()
                .WithUrl($"{domainUrl}/UpdateStatusImportHub")
                .Build();
        }
        public async Task Consume(ConsumeContext<UpdateStatusImportArticlesMessage> context)
        {
            _logger.LogWarning($"UpdateStatusImportArticlesConsumer: request={context.Message.ToJson()}");

            try
            {
                await _hubConnection.StartAsync();
                await _hubConnection.SendAsync("RaiseChangeStatusImportArticles", context.Message);
                await _hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

            _logger.LogInformation($"UpdateStatusImportArticleConsumer successed.");
        }
    }
}