using GalaSoft.MvvmLight.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using TrenteArpents.Extensions;
using TrenteArpents.Models;
using TrenteArpents.Repos;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class SponsorListViewModel : BaseListViewModel<Sponsor>
    {
        public SponsorListViewModel(INavigationService navigationService, IRepo<Sponsor> repo) : base(navigationService, repo)
        {
            Title = "Commanditaires";

            ItemTappedCommand = new Command<ItemTappedEventArgs>(OnItemTapped);
        }

        public ICommand ItemTappedCommand { get; }

        private void OnItemTapped(ItemTappedEventArgs eventArgs)
        {
            Sponsor sponsor = GetSponsor(eventArgs);

            if (sponsor != null)
            {
                GenericWebPageViewModel viewModel = new GenericWebPageViewModel
                {
                    Title = sponsor.Name,
                    Source = sponsor.PromoUrl
                };

                Navigation.NavigateTo(ViewModelLocator.GenericWebPageKey, viewModel);
            }
        }

        private Sponsor GetSponsor(ItemTappedEventArgs eventArgs)
        {
            return (Sponsor)eventArgs?.Item;
        }

        public override async Task RefreshAsync()
        {
            Items = await Repo.GetAsync(a => a.IsVisible).SetIsBusy(this);
        }
    }
}
