using Shopfloor.Notification.Hubs;

namespace Shopfloor.Notification.Extensions
{
    public static class AppExtensions
    {
        public static void MapHub(this WebApplication app)
        {
            app.MapHub<ChatHub>("/chathub");
            app.MapHub<UpdateStatusImportHub>("/UpdateStatusImportHub");
            app.MapHub<UpdateStatusExportHub>("/UpdateStatusExportHub");
        }
    }
}
