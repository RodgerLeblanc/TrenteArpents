using Com.OneSignal.Abstractions;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;

namespace TrenteArpents.AppCenterHandlers
{
    public class AppCenterDebugHandler : IAppCenterHandler
    {
        public void Start()
        {
            AppCenter.Start("ios=0435f9f8-0442-421a-9c28-d6936c1d44c6;" +
                "uwp=fff63baa-a995-4b7c-be70-d712ff684392;" +
                "android=7ea164fd-1895-4d6c-9d23-f80b4ca8ef4e;",
                typeof(Crashes));
        }

        public void OnNotificationReceived(OSNotification notification)
        {
        }

        public void OnNotificationOpened(OSNotificationOpenedResult result)
        {
        }

        public void OnInAppMessageClicked(OSInAppMessageAction action)
        {
        }
    }
}
