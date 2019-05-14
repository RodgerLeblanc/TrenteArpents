using Xamarin.Forms;
using System;
using System.Linq;
using TrenteArpents.ViewModels;
using System.Diagnostics;
using System.Collections.Generic;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration;

namespace TrenteArpents.Views
{
    public partial class MainMenuMaster : ContentPage
    {
        public MainMenuMaster()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeInsets = On<iOS>().SafeAreaInsets();
            title.Margin = new Thickness(0, Math.Max(safeInsets.Top, 10), 0, 0);
        }
    }
}
