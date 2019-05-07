using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "À propos";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
            MembersImageUrl = new UriImageSource
            {
                Uri = new Uri("https://i.postimg.cc/7LSwH0My/Alexandrine-Roger.jpg")
            };
        }

        public ICommand OpenWebCommand { get; }
        public UriImageSource MembersImageUrl { get; }
    }
}