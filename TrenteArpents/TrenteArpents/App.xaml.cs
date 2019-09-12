using Com.OneSignal;
using Com.OneSignal.Abstractions;
using GalaSoft.MvvmLight.Views;
#if !DEBUG
using Microsoft.AppCenter.Analytics;
#endif
using RestSharp;
using System.Collections.Generic;
using System.Net.Cache;
using TrenteArpents.AppCenterHandlers;
using TrenteArpents.Models;
using TrenteArpents.Repos;
using TrenteArpents.Services;
using TrenteArpents.ViewModels;
using TrenteArpents.Views;
using Xamarin.Forms;

namespace TrenteArpents
{
    public partial class App : Application
    {
        private IAppCenterHandler _appCenterHandler;

        static App()
        {
            RegisterIoc();
        }

        public App()
        {
            _appCenterHandler = DependencyInjection.Get<IAppCenterHandler>();

            InitializeComponent();

            MainPage = new MainPage();

            OneSignal.Current
                .StartInit("1c66c546-2aae-446e-9889-a1740f208fce")
                .HandleNotificationReceived(OnNotificationReceived)
                .HandleNotificationOpened(OnNotificationOpened)
                .HandleInAppMessageClicked(OnInAppMessageClicked)
                .UnsubscribeWhenNotificationsAreDisabled(true)
                .Settings(new Dictionary<string, bool>() {
                    { IOSSettings.kOSSettingsKeyAutoPrompt, true },
                    { IOSSettings.kOSSettingsKeyInAppLaunchURL, true } })
                .EndInit();
        }

        private void OnNotificationReceived(OSNotification notification)
        {
            _appCenterHandler.OnNotificationReceived(notification);
        }

        private void OnNotificationOpened(OSNotificationOpenedResult result)
        {
            _appCenterHandler.OnNotificationOpened(result);
        }

        private void OnInAppMessageClicked(OSInAppMessageAction action)
        {
            _appCenterHandler.OnInAppMessageClicked(action);
        }

        private static void RegisterIoc()
        {
#if DEBUG
            var cachePolicy = new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
            DependencyInjection.Register<IAppCenterHandler, AppCenterDebugHandler>();
#else
            var cachePolicy = new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
            DependencyInjection.Register<IAppCenterHandler, AppCenterHandler>();
#endif

            DependencyInjection.Register<AzureConfiguration>();
            DependencyInjection.Register<GitHubConfiguration>();
            DependencyInjection.Register<IRestClient>(() => new RestClient() { CachePolicy = cachePolicy });

            DependencyInjection.Register<IRepo<Activity>, ActivityRepo>();
            DependencyInjection.Register<IRepo<Album>, AlbumRepo>();
            DependencyInjection.Register<IRepo<Email>, EmailRepo>();
            DependencyInjection.Register<IRepo<Sponsor>, SponsorRepo>();

            DependencyInjection.RegisterSingleton<IAlertService, AlertService>();
            DependencyInjection.RegisterSingleton(() => GetNavigationService());
            DependencyInjection.Register<AboutViewModel>();
            DependencyInjection.Register<ActivityEditViewModel>();
            DependencyInjection.Register<ActivityListViewModel>();
            DependencyInjection.Register<AlbumListViewModel>();
            DependencyInjection.Register<ContactUsViewModel>();
            DependencyInjection.Register<MainMenuMasterViewModel>();
            DependencyInjection.Register<MotDeMDoyonViewModel>();
            DependencyInjection.Register<NewsletterViewModel>();
            DependencyInjection.Register<SocialViewModel>();
            DependencyInjection.Register<SponsorListViewModel>();

            DependencyInjection.Verify();
        }

        private static INavigationService GetNavigationService()
        {
            var navigationService = new NavigationService();

            navigationService.Configure(ViewModelLocator.AboutPageKey, typeof(About));
            navigationService.Configure(ViewModelLocator.ActivityEditPageKey, typeof(ActivityEdit));
            navigationService.Configure(ViewModelLocator.ActivityListPageKey, typeof(ActivityList));
            navigationService.Configure(ViewModelLocator.ContactUsPageKey, typeof(ContactUs));
            navigationService.Configure(ViewModelLocator.GenericWebPageKey, typeof(GenericWebPage));
            navigationService.Configure(ViewModelLocator.MainMenuPageKey, typeof(MainMenuMaster));
            navigationService.Configure(ViewModelLocator.MotDeMDoyonPageKey, typeof(MotDeMDoyon));
            navigationService.Configure(ViewModelLocator.NewsletterPageKey, typeof(Newsletter));
            navigationService.Configure(ViewModelLocator.PhotoListPageKey, typeof(Photos));
            navigationService.Configure(ViewModelLocator.SocialPageKey, typeof(Social));
            navigationService.Configure(ViewModelLocator.SponsorListKey, typeof(SponsorList));

            return navigationService;
        }

        protected override void OnStart()
        {
            _appCenterHandler.Start();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
