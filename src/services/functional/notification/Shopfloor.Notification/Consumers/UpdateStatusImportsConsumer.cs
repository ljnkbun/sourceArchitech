using MassTransit;
using Microsoft.AspNetCore.SignalR.Client;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Message;

namespace Shopfloor.Notification.Consumers
{
    public class UpdateStatusImportsConsumer : IConsumer<UpdateStatusImportsMessage>
    {
        private readonly ILogger<UpdateStatusImportsConsumer> _logger;
        private readonly HubConnection _hubConnection;
        public UpdateStatusImportsConsumer(ILogger<UpdateStatusImportsConsumer> logger,
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
        public async Task Consume(ConsumeContext<UpdateStatusImportsMessage> context)
        {
            _logger.LogWarning($"UpdateStatusImportsConsumer: request={context.Message.ToJson()}");

            try
            {
                await _hubConnection.StartAsync();
                await _hubConnection.SendAsync("RaiseChangeStatusImports", context.Message);
                await _hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

            _logger.LogInformation($"UpdateStatusImportsConsumer successed.");
        }
    }
}