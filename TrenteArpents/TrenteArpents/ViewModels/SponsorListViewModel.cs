using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}
