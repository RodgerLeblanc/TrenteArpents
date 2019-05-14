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
        public SponsorRepo(IRestClient client, IGitHubConfiguration configuration) : base(client, configuration)
        {
        }

        public override string GetResource() => "TrenteArpents/Sponsors/sponsors.json";
    }
}
