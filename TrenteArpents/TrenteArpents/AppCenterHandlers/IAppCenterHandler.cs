using Com.OneSignal.Abstractions;

namespace TrenteArpents.AppCenterHandlers
{
    public interface IAppCenterHandler
    {
        void Start();
        void OnNotificationReceived(OSNotification notification);
        void OnNotificationOpened(OSNotificationOpenedResult result);
        void OnInAppMessageClicked(OSInAppMessageAction action);
    }
}
