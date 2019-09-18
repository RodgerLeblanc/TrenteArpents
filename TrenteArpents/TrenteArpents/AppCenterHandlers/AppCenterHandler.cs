using Com.OneSignal.Abstractions;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using TrenteArpents.Extensions;

namespace TrenteArpents.AppCenterHandlers
{
    public class AppCenterHandler : IAppCenterHandler
    {
        public static readonly string NotificationReceivedTrackEventName = "Notification received";
        public static readonly string NotificationOpenedTrackEventName = "Notification opened";
        public static readonly string InAppMessageClickedTrackEventName = "In-App message clicked";

        public void Start()
        {
            AppCenter.Start(
                "ios=0435f9f8-0442-421a-9c28-d6936c1d44c6;" +
                "uwp=fff63baa-a995-4b7c-be70-d712ff684392;" +
                "android=7ea164fd-1895-4d6c-9d23-f80b4ca8ef4e;",
                typeof(Analytics),
                typeof(Crashes));
        }

        public void OnNotificationReceived(OSNotification notification)
        {
            Analytics.TrackEvent(NotificationReceivedTrackEventName, notification.ToDictionary());
        }

        public void OnNotificationOpened(OSNotificationOpenedResult result)
        {
            Analytics.TrackEvent(NotificationOpenedTrackEventName, result.ToDictionary());
        }

        public void OnInAppMessageClicked(OSInAppMessageAction action)
        {
            Analytics.TrackEvent(InAppMessageClickedTrackEventName, action.ToDictionary());
        }
    }
}
