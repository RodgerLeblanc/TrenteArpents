using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
    }
}
