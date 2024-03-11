using Microsoft.AspNetCore.SignalR;
using Shopfloor.EventBus.Models.Message;

namespace Shopfloor.Notification.Hubs
{
    public class UpdateStatusExportHub : Hub
    {
        public async Task RaiseChangeStatusExports(UpdateStatusExportsMessage exports)
        {
            await Clients.All.SendAsync("ReceiveChangeStatusExports", exports);
        }

        public async Task RaiseChangeStatusExportArticles(UpdateStatusExportArticlesMessage exportArticles)
        {
            await Clients.All.SendAsync("ReceiveChangeStatusExportArticles", exportArticles);
        }

        public async Task RaiseChangeStatusExportDetails(UpdateStatusExportDetailsMessage exportDetails)
        {
            await Clients.All.SendAsync("ReceiveChangeStatusExportDetails", exportDetails);
        }
    }
}
