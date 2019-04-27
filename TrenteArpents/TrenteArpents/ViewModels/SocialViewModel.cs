using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using TrenteArpents.Views;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class SocialViewModel : BaseViewModel
    {
        private const string facebookUrl = 
            "https://www.facebook.com/Comit%C3%A9-des-r%C3%A9sidents-du-Domaine-des-30-Arpents-107465872723807/";

        public SocialViewModel()
        {
            OpenFacebookCommand = new Command(() => Device.OpenUri(new Uri(facebookUrl)));
        }

        public ICommand OpenFacebookCommand { get; }
    }
}
