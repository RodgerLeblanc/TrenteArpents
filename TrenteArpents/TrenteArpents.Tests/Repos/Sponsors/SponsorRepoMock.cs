using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrenteArpents.Models;
using TrenteArpents.Repos;

namespace TrenteArpents.Tests.Repos
{
    public class SponsorRepoMock : BaseRepo<Sponsor>
    {
        public SponsorRepoMock(IRestClient client, IRepoConfiguration repoConfiguration) : base(client, repoConfiguration)
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
                    SponsorType = (SponsorType)(i % 4),
                    PromoUrl = new Uri("https://www.google.com")
                })
                .ToList();

            return Task.FromResult(sponsors);
        }
    }
}
