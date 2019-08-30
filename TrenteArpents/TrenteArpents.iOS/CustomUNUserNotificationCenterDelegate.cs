using Microsoft.AppCenter.Push;
using System;
using UserNotifications;

namespace TrenteArpents.iOS
{
    public class CustomUNUserNotificationCenterDelegate : UNUserNotificationCenterDelegate
    {
        public bool didReceiveNotificationInForeground { get; set; }

        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            didReceiveNotificationInForeground = true;

            // This callback overrides the system default behavior, so MSPush callback should be proxied manually.
            Push.DidReceiveRemoteNotification(notification.Request.Content.UserInfo);

            // Complete handling the notification.
            completionHandler(UNNotificationPresentationOptions.None);
        }

        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
        {
            // Pass the notification payload to MSPush.
            Push.DidReceiveRemoteNotification(response.Notification.Request.Content.UserInfo);

            // Complete handling the notification.
            completionHandler();
        }
    }
}