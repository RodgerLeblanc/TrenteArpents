using GalaSoft.MvvmLight.Views;
using System;
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
            Uri uri = GetUriFromItem(eventArgs);

            if (uri != null)
            {
                Device.OpenUri(uri);
            }
        }

        private Uri GetUriFromItem(ItemTappedEventArgs eventArgs)
        {
            Sponsor sponsor = (Sponsor)eventArgs?.Item;
            return sponsor?.PromoUrl;
        }

        public override async Task RefreshAsync()
        {
            Items = await Repo.GetAsync(a => a.IsVisible).SetIsBusy(this);
        }
    }
}
