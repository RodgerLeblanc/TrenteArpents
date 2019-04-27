using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TrenteArpents.Models;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class SponsorListViewModel : BaseViewModel
    {
        private static Assembly assembly;

        static SponsorListViewModel()
        {
            if (assembly == null)
            {
                assembly = typeof(SponsorListViewModel).GetTypeInfo().Assembly;
            }
        }

        public SponsorListViewModel()
        {
            Title = "Commanditaires";

            Sponsors = new List<Sponsor>
            {
                new Sponsor
                {
                    ImageSource = GetSponsorImage("domaineDes30Arpents.png"),
                    Name = "Domaine des 30 Arpents",
                    Type = SponsorType.Gold,
                },
                new Sponsor
                {
                    ImageSource = GetSponsorImage("groupeDoyon.png"),
                    Name = "Groupe Doyon",
                    Type = SponsorType.Gold,
                },
                new Sponsor
                {
                    ImageSource = GetSponsorImage("raynaldGiguere.png"),
                    Name = "Marché Raynald Giguère",
                    Type = SponsorType.Gold,
                },
            };
        }

        public IList<Sponsor> Sponsors { get; set; }

        private ImageSource GetSponsorImage(string fileName)
        {
            return ImageSource.FromResource($"TrenteArpents.Images.Sponsors.{fileName}", assembly);
        }
    }
}
