using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrenteArpents.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Facebook : ContentPage
    {
        public Facebook()
        {
            InitializeComponent();

            webView.Source = 
                "https://www.facebook.com/Comit%C3%A9-des-r%C3%A9sidents-du-Domaine-des-30-Arpents-107465872723807/";
        }
    }
}