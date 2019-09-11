using Foundation;
using Microsoft.AppCenter.Push;
using System;
using System.Diagnostics;
using UIKit;
using UserNotifications;

namespace TrenteArpents.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Stormlion.PhotoBrowser.iOS.Platform.Init();

            global::Xamarin.Forms.Forms.Init();

            FFImageLoading.FormsHandler.Init(debug: Debugger.IsAttached);

            LoadApplication(new App());

            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                UNUserNotificationCenter.Current.Delegate = new CustomUNUserNotificationCenterDelegate();
            }

            return base.FinishedLaunching(app, options);
        }

        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            bool result = Push.DidReceiveRemoteNotification(userInfo);
            if (result)
            {
                completionHandler(UIBackgroundFetchResult.NewData);
            }
            else
            {
                completionHandler(UIBackgroundFetchResult.NoData);
            }
        }

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
        }
    }
}
