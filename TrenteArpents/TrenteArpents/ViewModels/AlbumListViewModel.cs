using GalaSoft.MvvmLight.Views;
using Stormlion.PhotoBrowser;
using System.Linq;
using System.Windows.Input;
using TrenteArpents.Models;
using TrenteArpents.Repos;
using Xamarin.Forms;

//        private const string youtubeVideoUrl =
//"https://www.youtube.com/watch?v=PZRo_xz50sI";

//        {
//            "id": 5,
//    "imageUrl": "https://rodgerleblanc.github.io/TrenteArpents/Photos/videoScreenshot.png"
//}

namespace TrenteArpents.ViewModels
{
    public class AlbumListViewModel : BaseListViewModel<Album>
    {
        public AlbumListViewModel(INavigationService navigationService, IRepo<Album> repo) : base(navigationService, repo)
        {
            Title = "Photos";

            OpenPhotoBrowserCommand = new Command<Album>(OpenPhotoBrowser);
        }

        public ICommand OpenPhotoBrowserCommand { get; }

        private void OpenPhotoBrowser(Album album)
        {
            int count = album.Photos.Count;

            new PhotoBrowser
            {
                Photos = album.Photos.Select((p, index) => new Stormlion.PhotoBrowser.Photo
                {
                    URL = p.ImageUrl.OriginalString,
                    Title = $"{album.Title} ({index + 1}/{count})"
                })
                .ToList()
            }.Show();
        }
    }
}
