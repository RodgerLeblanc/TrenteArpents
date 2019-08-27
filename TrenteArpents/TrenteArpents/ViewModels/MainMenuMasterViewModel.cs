using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TrenteArpents.Models;
using TrenteArpents.Repos;
using TrenteArpents.Views;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class MainMenuMasterViewModel : BaseViewModel
    {
        public MainMenuMasterViewModel(IRepo<Sponsor> repo)
        {
            Repo = repo;

            DetailPages = GetDetailPages();

            FirstSponsorTappedCommand = new Command(OnFirstSponsorTapped);
            SecondSponsorTappedCommand = new Command(OnSecondSponsorTapped);
        }

        private IRepo<Sponsor> Repo { get; }
        public IList<DetailPageInfo> DetailPages { get; set; }
        public IList<Sponsor> Sponsors { get; set; }
        public bool HasSponsors { get => Sponsors != null && Sponsors.Any(); }
        public ICommand FirstSponsorTappedCommand { get; }
        public ICommand SecondSponsorTappedCommand { get; }

        protected override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            Sponsors = (await Repo.GetAsync()).ToList();
        }

        private IList<DetailPageInfo> GetDetailPages()
        {
            return DetailPages = new List<DetailPageInfo>
            {
                new DetailPageInfo
                {
                    Name = "Programmation",
                    ImageSource = ImageSource.FromFile("schedule.png"),
                    PageType = typeof(ActivityList)
                },
                new DetailPageInfo
                {
                    Name = "Partenaires",
                    ImageSource = ImageSource.FromFile("sponsors.png"),
                    PageType = typeof(SponsorList)
                },
                new DetailPageInfo
                {
                    Name = "Social",
                    ImageSource = ImageSource.FromFile("facebook.png"),
                    PageType = typeof(Social)
                },
                new DetailPageInfo
                {
                    Name = "Photos",
                    ImageSource = ImageSource.FromFile("photos.png"),
                    PageType = typeof(Photos)
                },
                new DetailPageInfo
                {
                    Name = "Mot de M. Doyon",
                    ImageSource = ImageSource.FromFile("message.png"),
                    PageType = typeof(MotDeMDoyon)
                },
                new DetailPageInfo
                {
                    Name = "Infolettre",
                    ImageSource = ImageSource.FromFile("email.png"),
                    PageType = typeof(About)
                },
                new DetailPageInfo
                {
                    Name = "À propos",
                    ImageSource = ImageSource.FromFile("about.png"),
                    PageType = typeof(About)
                },
                //https://mailchi.mp/c99dc0abfcc1/30arpents
                new DetailPageInfo
                {
                    Name = "Contactez-nous",
                    ImageSource = ImageSource.FromFile("email.png"),
                    PageType = typeof(ContactUs)
                },
            };
        }

        private void OnFirstSponsorTapped()
        {
            OpenPromoUrlForSponsorIndex(0);
        }

        private void OnSecondSponsorTapped()
        {
            OpenPromoUrlForSponsorIndex(1);
        }

        private void OpenPromoUrlForSponsorIndex(int index)
        {
            Sponsor sponsor = GetSponsorAtIndex(index);
            if (sponsor != null && sponsor.PromoUrl != null)
            {
                GenericWebPageViewModel viewModel = new GenericWebPageViewModel
                {
                    Title = sponsor.Name,
                    Source = sponsor.PromoUrl
                };

                Navigation.NavigateTo(ViewModelLocator.GenericWebPageKey, viewModel);

                if (App.Current.MainPage is MasterDetailPage masterDetail)
                {
                    masterDetail.IsPresented = false;
                }
            }
        }

        private Sponsor GetSponsorAtIndex(int index)
        {
            return Sponsors?.ElementAt(index);
        }
    }

    public class DetailPageInfo
    {
        public string Name { get; set; }
        public ImageSource ImageSource { get; set; }
        public Type PageType { get; set; }
    }
}
