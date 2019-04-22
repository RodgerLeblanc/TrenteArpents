using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrenteArpents.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrenteArpents.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleList : ContentPage
    {
        public ScheduleList()
        {
            BindingContext = new ScheduleListViewModel();
            InitializeComponent();
        }
    }
}