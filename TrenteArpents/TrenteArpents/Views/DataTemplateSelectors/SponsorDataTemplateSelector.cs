using System;
using System.Collections.Generic;
using System.Text;
using TrenteArpents.Models;
using Xamarin.Forms;

namespace TrenteArpents.Views
{
    public class SponsorDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GoldSponsorTemplate { get; set; }
        public DataTemplate SilverSponsorTemplate { get; set; }
        public DataTemplate BronzeSponsorTemplate { get; set; }
        public DataTemplate LocalSponsorTemplate { get; set; }
        public DataTemplate OtherSponsorTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Sponsor sponsor = (Sponsor)item;

            switch (sponsor.SponsorType)
            {
                case SponsorType.Gold:
                    return GoldSponsorTemplate;
                case SponsorType.Silver:
                    return SilverSponsorTemplate;
                case SponsorType.Bronze:
                    return BronzeSponsorTemplate;
                case SponsorType.Local:
                    return LocalSponsorTemplate;
                case SponsorType.Other:
                default:
                    return OtherSponsorTemplate;
            }
        }
    }
}
