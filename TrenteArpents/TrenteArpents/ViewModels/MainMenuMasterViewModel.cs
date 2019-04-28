using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
        private static Assembly assembly;

        static MainMenuMasterViewModel()
        {
            if (assembly == null)
            {
                assembly = typeof(MainMenuMasterViewModel).GetTypeInfo().Assembly;
            }
        }

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
                    ImageSource = GetIconFromResource("schedule.png"),
                    PageType = typeof(ScheduleList)
                },
                new DetailPageInfo
                {
                    Name = "Commanditaires",
                    ImageSource = GetIconFromResource("sponsors.png"),
                    PageType = typeof(SponsorList)
                },
                new DetailPageInfo
                {
                    Name = "Social",
                    ImageSource = GetIconFromResource("facebook.png"),
                    PageType = typeof(Social)
                },
                new DetailPageInfo
                {
                    Name = "Multimédia",
                    ImageSource = GetIconFromResource("photos.png"),
                    PageType = typeof(Multimedia)
                },
                new DetailPageInfo
                {
                    Name = "À propos",
                    ImageSource = GetIconFromResource("about.png"),
                    PageType = typeof(About)
                },
            };
        }

        private void OnFirstSponsorTapped()
        {
            if (Sponsors?.FirstOrDefault() is Sponsor sponsor && sponsor.PromoUrl != null)
            {
                Device.OpenUri(sponsor.PromoUrl);
            }
        }

        private void OnSecondSponsorTapped()
        {
            if (Sponsors?.Skip(1).FirstOrDefault() is Sponsor sponsor && sponsor.PromoUrl != null)
            {
                Device.OpenUri(sponsor.PromoUrl);
            }
        }

        private ImageSource GetIconFromResource(string fileName)
        {
            return ImageSource.FromResource($"TrenteArpents.Images.Icons.{fileName}", assembly);
        }
    }

    public class DetailPageInfo
    {
        public string Name { get; set; }
        public ImageSource ImageSource { get; set; }
        public Type PageType { get; set; }
    }
}
