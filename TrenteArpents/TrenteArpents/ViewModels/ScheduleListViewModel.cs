using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TrenteArpents.Models;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class ScheduleListViewModel : BaseViewModel
    {
        private static Assembly assembly;

        static ScheduleListViewModel()
        {
            if (assembly == null)
            {
                assembly = typeof(ScheduleListViewModel).GetTypeInfo().Assembly;
            }
        }

        public ScheduleListViewModel()
        {
            Activities = Enumerable
                .Range(0, 10)
                .Select(i => new Activity
                {
                    Name = $"Name {i}",
                    Description = $"Description {i}",
                    Time = "10:00 - 11:00",
                    ImageSource = GetSponsorImage("raynaldGiguere.png")
                })
                .ToList();

            HeaderSponsors = new List<Sponsor>
            {
                new Sponsor { ImageSource = GetSponsorImage("domaineDes30Arpents.png") },
                new Sponsor { ImageSource = GetSponsorImage("groupeDoyon.png") },
                new Sponsor { ImageSource = GetSponsorImage("raynaldGiguere.png") },
            };
        }

        private ImageSource GetSponsorImage(string fileName)
        {
            return ImageSource.FromResource($"TrenteArpents.Images.Sponsors.{fileName}", assembly);
        }

        public IList<Activity> Activities { get; set; }
        public Activity SelectedActivity { get; set; }
        public IList<Sponsor> HeaderSponsors { get; set; }
        public bool ScheduleVisible { get => Activities.Any(); }
        public bool NoScheduleVisible { get => !Activities.Any(); }
    }
}
