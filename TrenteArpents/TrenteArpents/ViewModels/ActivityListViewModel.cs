using GalaSoft.MvvmLight.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using TrenteArpents.Extensions;
using TrenteArpents.Models;
using TrenteArpents.Repos;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class ActivityListViewModel : BaseListViewModel<Activity>
    {
        public ActivityListViewModel(INavigationService navigationService, IRepo<Activity> repo) : base(navigationService, repo)
        {
            Title = "Programmation";

            ItemTappedCommand = new Command<ItemTappedEventArgs>(OnItemTapped);
        }

        public ICommand ItemTappedCommand { get; }

        private void OnItemTapped(ItemTappedEventArgs eventArgs)
        {
            Activity activity = GetActivity(eventArgs);

            if (activity != null)
            {
                GenericWebPageViewModel viewModel = new GenericWebPageViewModel
                {
                    Title = activity.Name,
                    //Source = activity.PromoUrl
                };

                Navigation.NavigateTo(ViewModelLocator.GenericWebPageKey, viewModel);
            }
        }

        private Activity GetActivity(ItemTappedEventArgs eventArgs)
        {
            return (Activity)eventArgs?.Item;
        }

        public override async Task RefreshAsync()
        {
            Items = await Repo.GetAsync(a => a.IsVisible).SetIsBusy(this);
        }
    }
}
