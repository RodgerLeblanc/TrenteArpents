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
    public partial class Photos : ContentPage
    {
        public Photos()
        {
            InitializeComponent();

            webView.Source = 
                "https://www.facebook.com/pg/Comit%C3%A9-des-r%C3%A9sidents-du-Domaine-des-30-Arpents-107465872723807/photos/?tab=album&album_id=1377116752425373";
        }
    }
}