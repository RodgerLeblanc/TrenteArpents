using Xamarin.Forms;
using System;
using System.Linq;
using TrenteArpents.ViewModels;
using System.Diagnostics;

namespace TrenteArpents.Views
{
    public partial class MainMenuMaster : ContentPage
    {
        public MainMenuMaster()
        {
            InitializeComponent();
            BindingContext = new MainMenuMasterViewModel();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is DetailPageInfo detailPageInfo))
                return;

            if (!(Application.Current.MainPage is MasterDetailPage masterDetailPage))
                return;

            ListView listView = (ListView)sender;
            listView.SelectedItem = null;

            Page page = (Page)Activator.CreateInstance(detailPageInfo.PageType);
            masterDetailPage.Detail = new NavigationPage(page);

            masterDetailPage.IsPresented = false;
        }
    }
}
