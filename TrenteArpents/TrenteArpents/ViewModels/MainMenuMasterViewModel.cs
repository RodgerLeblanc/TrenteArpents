using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                    PageType = typeof(ScheduleList)
                },
                new DetailPageInfo
                {
                    Name = "Commanditaires",
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
                    Name = "Multimédia",
                    ImageSource = ImageSource.FromFile("photos.png"),
                    PageType = typeof(Multimedia)
                },
                new DetailPageInfo
                {
                    Name = "Mot de M. Doyon",
                    ImageSource = ImageSource.FromFile("message.png"),
                    PageType = typeof(MotDeMDoyon)
                },
                new DetailPageInfo
                {
                    Name = "À propos",
                    ImageSource = ImageSource.FromFile("about.png"),
                    PageType = typeof(About)
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
                Device.OpenUri(sponsor.PromoUrl);
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
