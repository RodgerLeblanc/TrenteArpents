using GalaSoft.MvvmLight.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using RestSharp;
using System.Net.Cache;
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
        static App()
        {
            RegisterIoc();
        }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        private static void RegisterIoc()
        {
#if DEBUG
            var cachePolicy = new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
#else
            var cachePolicy = new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
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
            AppCenter.Start("ios=0435f9f8-0442-421a-9c28-d6936c1d44c6;" +
                "uwp=fff63baa-a995-4b7c-be70-d712ff684392;" +
                "android=7ea164fd-1895-4d6c-9d23-f80b4ca8ef4e;",
                typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
