using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TrenteArpents.Models;
using TrenteArpents.Repos;

namespace TrenteArpents.Tests.Repos
{
    public class SponsorRepoMock : BaseRepo<Sponsor>
    {
        public SponsorRepoMock(IRestClient client) : base(client)
        {
        }

        public override string GetResource() => String.Empty;

        public override Task<IEnumerable<Sponsor>> GetAsync()
        {
            IEnumerable<Sponsor> sponsors = Enumerable
                .Range(1, 10)
                .Select(i => new Sponsor
                {
                    Id = i,
                    Name = $"Sponsor #{i}",
                    ImageUrl = new Uri($"https://via.placeholder.com/150?text={i}"),
                    SponsorType = i % 3,
                    PromoUrl = new Uri("https://www.google.com")
                })
                .ToList();

            return Task.FromResult(sponsors);
        }
    }
}
