using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrenteArpents.Services
{
    public class NavigationService : INavigationService
    {
        private Dictionary<string, Type> pageTypeMapper = new Dictionary<string, Type>();

        public string CurrentPageKey { get; }

        public void GoBack()
        {
            Task unawaitedTask = Application.Current.MainPage.Navigation.PopAsync();
        }

        public void NavigateTo(string pageKey)
        {
            if (!pageTypeMapper.ContainsKey(pageKey))
            {
                throw new KeyNotFoundException($"The key {pageKey} was not found.");
            }

            var page = (Page)Activator.CreateInstance(pageTypeMapper[pageKey]);
            Task unawaitedTask = PushAsync(page);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            if (!pageTypeMapper.ContainsKey(pageKey))
            {
                throw new KeyNotFoundException($"The key {pageKey} was not found.");
            }

            var page = (Page)Activator.CreateInstance(pageTypeMapper[pageKey], parameter);
            Task unawaitedTask = PushAsync(page);
        }

        private Task PushAsync(Page page)
        {
            INavigation navigation = GetNavigation(Application.Current.MainPage);
            return navigation.PushAsync(page);
        }

        private INavigation GetNavigation(Page mainPage)
        {
            switch (mainPage)
            {
                case MasterDetailPage masterDetail:
                    return masterDetail.Detail.Navigation;
                case NavigationPage navigationPage:
                    return navigationPage.Navigation;
                default:
                    return Application.Current.MainPage.Navigation;
            }
        }

        public void Configure(string key, Type pageType)
        {
            if (pageTypeMapper.ContainsKey(key))
            {
                pageTypeMapper.Remove(key);
            }

            pageTypeMapper.Add(key, pageType);
        }
    }
}
