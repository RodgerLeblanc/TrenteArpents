using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using System.Diagnostics;

namespace TrenteArpents.Droid
{
    [Activity(Label = "TrenteArpents", Icon = "@mipmap/ic_launcher", Theme = "@style/SplashScreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.SetTheme(Resource.Style.MainTheme);
            base.OnCreate(savedInstanceState);

            LockDeviceOrientation();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            Forms.Init(this, savedInstanceState);

            Android.Glide.Forms.Init(debug: Debugger.IsAttached);

            LoadApplication(new App());
        }

        private void LockDeviceOrientation()
        {
            switch (Device.Idiom)
            {
                case TargetIdiom.Desktop:
                case TargetIdiom.Tablet:
                case TargetIdiom.TV:
                    RequestedOrientation = ScreenOrientation.SensorLandscape;
                    break;

                case TargetIdiom.Phone:
                case TargetIdiom.Watch:
                case TargetIdiom.Unsupported:
                default:
                    RequestedOrientation = ScreenOrientation.Portrait;
                    break;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}