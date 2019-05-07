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
    public class PhotoListViewModel : BaseListViewModel<Photo>
    {
        public PhotoListViewModel(INavigationService navigationService, IRepo<Photo> repo) : base(navigationService, repo)
        {
        }

        public override async Task RefreshAsync()
        {
            var x = Items;
            await base.RefreshAsync();
        }
    }
}
