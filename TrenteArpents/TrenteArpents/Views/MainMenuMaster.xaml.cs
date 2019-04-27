using Xamarin.Forms;
using System;
using System.Linq;
using TrenteArpents.ViewModels;
using System.Diagnostics;
using System.Collections.Generic;

namespace TrenteArpents.Views
{
    public partial class MainMenuMaster : ContentPage
    {
        public MainMenuMaster()
        {
            InitializeComponent();
            BindingContext = new MainMenuMasterViewModel();
        }
    }
}
