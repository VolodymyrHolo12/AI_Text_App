using Microsoft.Toolkit.Uwp.Notifications;

namespace AITextApp.Services.Interfaces
{
    public interface INotificationService
    {
        void ShowNotification(string title, string message, 
            string action, int conversationId, 
            Uri? inlineImageUrl = null, Uri? appLogoUri = null, 
            ToastGenericAppLogoCrop appLogoCrop = ToastGenericAppLogoCrop.None);
    }
}
