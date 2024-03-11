using MassTransit;
using Microsoft.AspNetCore.SignalR.Client;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Message;

namespace Shopfloor.Notification.Consumers
{
    public class UpdateStatusExportDetailsConsumer : IConsumer<UpdateStatusExportDetailsMessage>
    {
        private readonly ILogger<UpdateStatusExportDetailsConsumer> _logger;
        private readonly HubConnection _hubConnection;
        public UpdateStatusExportDetailsConsumer(ILogger<UpdateStatusExportDetailsConsumer> logger,
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
        public async Task Consume(ConsumeContext<UpdateStatusExportDetailsMessage> context)
        {
            _logger.LogWarning($"UpdateStatusExportDetailsConsumer: request={context.Message.ToJson()}");

            try
            {
                await _hubConnection.StartAsync();
                await _hubConnection.SendAsync("RaiseChangeStatusExportDetails", context.Message);
                await _hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

            _logger.LogInformation($"UpdateStatusExportDetailConsumer successed.");
        }
    }
}