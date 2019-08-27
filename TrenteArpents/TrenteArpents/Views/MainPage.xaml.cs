using System.Windows.Input;
using Xamarin.Forms;

namespace TrenteArpents.Views
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();

            RandomPageCommand = new Command(() => { });

            BindingContext = this;
        }

        public ICommand RandomPageCommand { get; set; }
    }
}