using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public class SponsorRepo : BaseGitHubRepo<Sponsor>
    {
        public SponsorRepo(IRestClient client, GitHubConfiguration configuration) : base(client, configuration)
        {
        }

        public override string GetResource() => "TrenteArpents/Sponsors/sponsors.json";
    }
}
