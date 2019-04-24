using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
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

        public MainMenuMasterViewModel()
        {
            DetailPages = new List<DetailPageInfo>
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
                    PageType = typeof(Facebook)
                },
                new DetailPageInfo
                {
                    Name = "Photos",
                    ImageSource = GetIconFromResource("photos.png"),
                    PageType = typeof(Photos)
                },
                new DetailPageInfo
                {
                    Name = "À propos",
                    ImageSource = GetIconFromResource("about.png"),
                    PageType = typeof(ScheduleList)
                },
            };
        }

        private ImageSource GetIconFromResource(string fileName)
        {
            return ImageSource.FromResource($"TrenteArpents.Images.Icons.{fileName}", assembly);
        }

        public IList<DetailPageInfo> DetailPages { get; set; }
    }

    public class DetailPageInfo
    {
        public string Name { get; set; }
        public ImageSource ImageSource { get; set; }
        public Type PageType { get; set; }
    }
}
