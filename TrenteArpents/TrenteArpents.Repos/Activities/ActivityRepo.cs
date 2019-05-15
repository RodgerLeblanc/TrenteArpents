using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public class ActivityRepo : BaseGitHubRepo<Activity>
    {
        public ActivityRepo(IRestClient client, GitHubConfiguration configuration) : base(client, configuration)
        {
        }

        public override string GetResource() => "TrenteArpents/Activities/activities.json";
    }
}
