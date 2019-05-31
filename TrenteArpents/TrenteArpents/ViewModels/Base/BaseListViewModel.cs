using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrenteArpents.Extensions;
using TrenteArpents.Models;
using TrenteArpents.Repos;

namespace TrenteArpents.ViewModels
{
    public abstract class BaseListViewModel<TModel, TListItemViewModel> : BaseViewModel
        where TModel : IModel, new()
        where TListItemViewModel : BaseEditViewModel<TModel>
    {
        public BaseListViewModel(IRepo<TModel> repo) : base()
        {
            Repo = repo;
        }

        public BaseListViewModel(IMessenger messenger, IRepo<TModel> repo) : base(messenger)
        {
            Repo = repo;
        }

        public BaseListViewModel(INavigationService navigation, IRepo<TModel> repo) : base(navigation)
        {
            Repo = repo;
        }

        public BaseListViewModel(IMessenger messenger, INavigationService navigation, IRepo<TModel> repo) : base(messenger, navigation)
        {
            Repo = repo;
        }

        protected IRepo<TModel> Repo { get; }
        public IEnumerable<TListItemViewModel> Items { get; set; }
        public TListItemViewModel SelectedItem { get; set; }
        public bool HasItems { get => Items != null && Items.Any(); }
        public bool HasNoItems { get => !HasItems; }
        public string NoItemsText { get => IsBusy ? "Chargement..." : "Aucun item disponible"; }

        protected abstract Task RefreshAsync();

        protected override async Task OnAppearingAsync()
        {
            await RefreshAsync();
        }
    }

    public abstract class BaseListViewModel<TModel> : BaseViewModel
        where TModel : IModel, new()
    {
        public BaseListViewModel(IRepo<TModel> repo) : base()
        {
            Repo = repo;
        }

        public BaseListViewModel(IMessenger messenger, IRepo<TModel> repo) : base(messenger)
        {
            Repo = repo;
        }

        public BaseListViewModel(INavigationService navigation, IRepo<TModel> repo) : base(navigation)
        {
            Repo = repo;
        }

        public BaseListViewModel(IMessenger messenger, INavigationService navigation, IRepo<TModel> repo) : base(messenger, navigation)
        {
            Repo = repo;
        }

        protected IRepo<TModel> Repo { get; }
        public IEnumerable<TModel> Items { get; set; }
        public TModel SelectedItem { get; set; }
        public bool HasItems { get => Items != null && Items.Any(); }
        public bool HasNoItems { get => !HasItems; }
        public string NoItemsText { get => IsBusy ? "Chargement..." : "Aucun item disponible"; }

        protected virtual async Task RefreshAsync()
        {
            Items = await Repo.GetAsync().SetIsBusy(this);
        }

        protected override async Task OnAppearingAsync()
        {
            await RefreshAsync();
        }
    }
}
