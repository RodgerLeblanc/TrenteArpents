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
        Dictionary<Type, Page> pageCache = new Dictionary<Type, Page>();

        public MainMenuMaster()
        {
            InitializeComponent();
            BindingContext = new MainMenuMasterViewModel();
        }

        private MasterDetailPage MasterDetailPage
        {
            get 
            {
                if (Parent is MasterDetailPage masterDetailPage)
                {
                    return masterDetailPage;
                }

                return Application.Current.MainPage as MasterDetailPage;
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is DetailPageInfo detailPageInfo))
                return;

            RemoveSelection();
            SetDetailPage(detailPageInfo);
            CloseMasterPage();
        }

        private void RemoveSelection()
        {
            listView.SelectedItem = null;
        }

        private void SetDetailPage(DetailPageInfo detailPageInfo)
        {
            if (MasterDetailPage.Detail.GetType() == detailPageInfo.PageType)
            {
                return;
            }

            MasterDetailPage.Detail = GetDetailPage(detailPageInfo.PageType);
        }

        private Page GetDetailPage(Type pageType)
        {
            if (pageCache.ContainsKey(pageType))
            {
                return pageCache[pageType];
            }

            Page page = (Page)Activator.CreateInstance(pageType);
            NavigationPage navigationPage = new NavigationPage(page);

            AddPageToCache(pageType, navigationPage);
            return navigationPage;
        }

        private void AddPageToCache(Type pageType, NavigationPage navigationPage)
        {
            pageCache.Add(pageType, navigationPage);
        }

        private void CloseMasterPage()
        {
            MasterDetailPage.IsPresented = false;
        }
    }
}
