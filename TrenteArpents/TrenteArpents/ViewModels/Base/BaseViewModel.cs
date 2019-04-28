using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public abstract class BaseViewModel : ViewModelBase
    {
        public BaseViewModel() : base()
        {
            Navigation = App.Container.GetInstance<INavigationService>();
            SetCommands();
        }

        public BaseViewModel(IMessenger messenger) : base(messenger)
        {
            Navigation = App.Container.GetInstance<INavigationService>();
            SetCommands();
        }

        public BaseViewModel(INavigationService navigation) : base()
        {
            Navigation = navigation;
            SetCommands();
        }

        public BaseViewModel(IMessenger messenger, INavigationService navigation) : base(messenger)
        {
            Navigation = navigation;
            SetCommands();
        }

        public INavigationService Navigation { get; }
        public bool IsBusy { get; set; }
        public string Title { get; set; }
        public ICommand AppearingCommand { get; private set; }
        private ICommand AppearingAsyncCommand { get; set; }

        private void SetCommands()
        {
            AppearingCommand = new Command(OnAppearing);
            AppearingAsyncCommand = new Command(async () => await OnAppearingAsync());
        }

        protected virtual void OnAppearing()
        {
            if (AppearingAsyncCommand != null && AppearingAsyncCommand.CanExecute(null))
            {
                AppearingAsyncCommand.Execute(null);
            }
        }

        protected virtual Task OnAppearingAsync()
        {
            return Task.CompletedTask;
        }
    }
}
