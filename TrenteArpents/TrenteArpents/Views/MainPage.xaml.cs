using Xamarin.Forms;

namespace TrenteArpents.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new Photos());
        }
    }
}