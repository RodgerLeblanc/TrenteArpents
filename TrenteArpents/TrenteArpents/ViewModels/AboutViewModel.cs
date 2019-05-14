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

            MembersImageUrl = ImageSource.FromUri(new Uri("https://rodgerleblanc.github.io/TrenteArpents/Members/Images/AlexandrineRoger.jpg"));
        }

        public ImageSource MembersImageUrl { get; }
    }
}