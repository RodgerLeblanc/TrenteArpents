/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:BasicNavigation.iOS"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using SimpleInjector;
using TrenteArpents.Services;
using TrenteArpents.Views;

namespace TrenteArpents.ViewModels
{
    public class ViewModelLocator
    {
        public const string AboutPageKey = nameof(AboutPageKey);
        public const string MainMenuPageKey = nameof(MainMenuPageKey);
        public const string MultiMediaPageKey = nameof(MultiMediaPageKey);
        public const string ScheduleListPageKey = nameof(ScheduleListPageKey);
        public const string SocialPageKey = nameof(SocialPageKey);
        public const string SponsorListKey = nameof(SponsorListKey);

        public AboutViewModel AboutViewModel { get => App.Container.GetInstance<AboutViewModel>(); }
        public MainMenuMasterViewModel MainMenuMasterViewModel { get => App.Container.GetInstance<MainMenuMasterViewModel>(); }
        public MultimediaViewModel MultimediaViewModel { get => App.Container.GetInstance<MultimediaViewModel>(); }
        public ScheduleListViewModel ScheduleListViewModel { get => App.Container.GetInstance<ScheduleListViewModel>(); }
        public SocialViewModel SocialViewModel { get => App.Container.GetInstance<SocialViewModel>(); }
        public SponsorListViewModel SponsorListViewModel { get => App.Container.GetInstance<SponsorListViewModel>(); }
    }
}