using GalaSoft.MvvmLight.Views;
using System.Linq;
using System.Threading.Tasks;
using TrenteArpents.Extensions;
using TrenteArpents.Helpers;
using TrenteArpents.Models;
using TrenteArpents.Repos;

namespace TrenteArpents.ViewModels
{
    public class ActivityListViewModel : BaseListViewModel<Activity, ActivityEditViewModel>
    {
        public ActivityListViewModel(INavigationService navigationService, IRepo<Activity> repo, IHeartService heartService) : base(navigationService, repo)
        {
            HeartService = heartService;

            Title = "Programmation";
        }

        protected IHeartService HeartService { get; }

        protected override async Task RefreshAsync()
        {
            var hearts = await HeartService.GetAsync();

            var items = await Repo.GetAsync(a => a.IsVisible).SetIsBusy(this);
            Items = items.Select(i => new ActivityEditViewModel(i)).ToList();
        }
    }
}
