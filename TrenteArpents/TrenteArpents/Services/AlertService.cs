using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrenteArpents.Services
{
    public class AlertService : IAlertService
    {
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            Page page = GetCurrentPage();
            await page.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            Page page = GetCurrentPage();
            return await page.DisplayAlert(title, message, accept, cancel);
        }

        private Page GetCurrentPage()
        {
            switch (Application.Current.MainPage)
            {
                case MasterDetailPage masterDetail:
                    return masterDetail.Detail;
                case NavigationPage navigationPage:
                    return navigationPage.CurrentPage;
                default:
                    return Application.Current.MainPage;
            }
        }
    }
}
