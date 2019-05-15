using CellNinja.Controls;
using TrenteArpents.ViewModels;
using Xamarin.Forms.Xaml;

namespace TrenteArpents.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenericWebPage : CNWebViewPage
    {
        public GenericWebPage(GenericWebPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}