using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class MultimediaViewModel : BaseViewModel
    {
        private const string facebookPhotosUrl =
            "https://www.facebook.com/pg/Comit%C3%A9-des-r%C3%A9sidents-du-Domaine-des-30-Arpents-107465872723807/photos/?tab=album&album_id=1377116752425373";

        private const string youtubeVideoUrl =
            "https://www.youtube.com/watch?v=PZRo_xz50sI";

        public MultimediaViewModel(PhotoListViewModel photoListViewModel)
        {
            Title = "Multimédia";

            Photos = photoListViewModel;

            OpenFacebookPhotosCommand = new Command(() => Device.OpenUri(new Uri(facebookPhotosUrl)));
            OpenVideoCommand = new Command(() => Device.OpenUri(new Uri(youtubeVideoUrl)));
        }

        public PhotoListViewModel Photos { get; }

        public ICommand OpenFacebookPhotosCommand { get; }
        public ICommand OpenVideoCommand { get; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            await Photos.RefreshAsync();
        }
    }
}
