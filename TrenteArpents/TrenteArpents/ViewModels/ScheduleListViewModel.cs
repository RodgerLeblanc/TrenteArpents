using GalaSoft.MvvmLight.Views;
using System.Threading.Tasks;
using TrenteArpents.Extensions;
using TrenteArpents.Models;
using TrenteArpents.Repos;

namespace TrenteArpents.ViewModels
{
    public class ScheduleListViewModel : BaseListViewModel<Activity>
    {
        public ScheduleListViewModel(INavigationService navigationService, IRepo<Activity> repo) : base(navigationService, repo)
        {
            Title = "Programmation";
        }

        public override async Task RefreshAsync()
        {
            Items = await Repo.GetAsync(a => a.IsVisible).SetIsBusy(this);
        }
    }
}
