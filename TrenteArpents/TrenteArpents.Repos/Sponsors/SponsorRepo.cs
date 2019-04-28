using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public class SponsorRepo : BaseGitHubRepo<Sponsor>
    {
        private const string resource = "TrenteArpents/Sponsors/sponsors.json";

        public SponsorRepo(IRestClient client) : base(client)
        {
        }

        public override string Resource { get; } = resource;
    }
}
