using AITextApp.Services.Interfaces;
using Microsoft.Toolkit.Uwp.Notifications;

namespace AITextApp.Services
{
    public class WindowsNotificationService : INotificationService
    {
        public void ShowNotification(string title, string message, 
            string action, int conversationId, 
            Uri? inlineImageUrl = null, Uri? appLogoUri = null, 
            ToastGenericAppLogoCrop appLogoCrop = ToastGenericAppLogoCrop.None)
        {
            var toastBuilder = new ToastContentBuilder()
                .AddArgument("action", action)
                .AddArgument("conversationId", conversationId)
                .AddText(title)
                .AddText(message);

            if (inlineImageUrl is not null)
            {
                toastBuilder.AddInlineImage(inlineImageUrl);
            }

            if (appLogoUri is not null)
            {
                toastBuilder.AddAppLogoOverride(appLogoUri, appLogoCrop);
            }

             toastBuilder.Show();
        }
    }
}
