using Microsoft.AspNetCore.SignalR;
using Shopfloor.EventBus.Models.Message;

namespace Shopfloor.Notification.Hubs
{
    public class UpdateStatusImportHub : Hub
    {
        public async Task RaiseChangeStatusImports(UpdateStatusImportsMessage imports)
        {
            await Clients.All.SendAsync("ReceiveChangeStatusImports", imports);
        }

        public async Task RaiseChangeStatusImportArticles(UpdateStatusImportArticlesMessage importArticles)
        {
            await Clients.All.SendAsync("ReceiveChangeStatusImportArticles", importArticles);
        }

        public async Task RaiseChangeStatusImportDetails(UpdateStatusImportDetailsMessage importDetails)
        {
            await Clients.All.SendAsync("ReceiveChangeStatusImportDetails", importDetails);
        }
    }
}
