using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TrenteArpents.Models
{
    public class Sponsor
    {
        public string Name { get; set; }
        public ImageSource ImageSource { get; set; }
        public SponsorType Type { get; set; } = SponsorType.Bronze;
    }

    public enum SponsorType
    {
        Gold,
        Silver,
        Bronze,
    }
}
