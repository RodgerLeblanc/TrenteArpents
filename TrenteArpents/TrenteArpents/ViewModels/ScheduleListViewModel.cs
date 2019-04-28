using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using TrenteArpents.Models;
using TrenteArpents.Repos;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class ScheduleListViewModel : BaseListViewModel<Activity>
    {
        public ScheduleListViewModel(INavigationService navigationService, IRepo<Activity> repo) : base(navigationService, repo)
        {
            Title = "Programmation";
        }
    }
}
