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

namespace TrenteArpents.ViewModels
{
    public class ViewModelLocator
    {
        public const string AboutPageKey = nameof(AboutPageKey);
        public const string ContactUsPageKey = nameof(ContactUsPageKey);
        public const string GenericWebPageKey = nameof(GenericWebPageKey);
        public const string MainMenuPageKey = nameof(MainMenuPageKey);
        public const string MotDeMDoyonPageKey = nameof(MotDeMDoyonPageKey);
        public const string PhotoListPageKey = nameof(PhotoListPageKey);
        public const string ScheduleListPageKey = nameof(ScheduleListPageKey);
        public const string SocialPageKey = nameof(SocialPageKey);
        public const string SponsorListKey = nameof(SponsorListKey);

        public AboutViewModel AboutViewModel { get => DependencyInjection.Get<AboutViewModel>(); }
        public AlbumListViewModel AlbumListViewModel { get => DependencyInjection.Get<AlbumListViewModel>(); }
        public ContactUsViewModel ContactUsViewModel { get => DependencyInjection.Get<ContactUsViewModel>(); }
        public MainMenuMasterViewModel MainMenuMasterViewModel { get => DependencyInjection.Get<MainMenuMasterViewModel>(); }
        public MotDeMDoyonViewModel MotDeMDoyonViewModel { get => DependencyInjection.Get<MotDeMDoyonViewModel>(); }
        public ScheduleListViewModel ScheduleListViewModel { get => DependencyInjection.Get<ScheduleListViewModel>(); }
        public SocialViewModel SocialViewModel { get => DependencyInjection.Get<SocialViewModel>(); }
        public SponsorListViewModel SponsorListViewModel { get => DependencyInjection.Get<SponsorListViewModel>(); }
    }
}