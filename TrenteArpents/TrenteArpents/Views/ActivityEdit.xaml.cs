using TrenteArpents.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrenteArpents.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityEdit : ContentPage
    {
        public ActivityEdit(ActivityEditViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}