using MassTransit;
using Microsoft.AspNetCore.SignalR.Client;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Message;

namespace Shopfloor.Notification.Consumers
{
    public class ChatMessageConsumer : IConsumer<ChatMessage>
    {
        private readonly ILogger<ChatMessageConsumer> _logger;
        private readonly HubConnection _hubConnection;
        public ChatMessageConsumer(ILogger<ChatMessageConsumer> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _hubConnection = new HubConnectionBuilder()
                .WithUrl($"{configuration["DomainUrl"]}/chathub")
                .Build();
        }
        public async Task Consume(ConsumeContext<ChatMessage> context)
        {
            _logger.LogWarning($"ChatMessageConsumer: request={context.Message.ToJson()}");

            try
            {
                await _hubConnection.StartAsync();
                await _hubConnection.SendAsync("SendMessage", context.Message.User, context.Message.Message);
                await _hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

            _logger.LogInformation($"ChatMessageConsumer successed.");
        }
    }
}