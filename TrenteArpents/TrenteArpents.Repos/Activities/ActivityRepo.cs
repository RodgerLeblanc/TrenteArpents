using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public class ActivityRepo : BaseGitHubRepo<Activity>
    {
        private const string resource = "TrenteArpents/Activities/activities.json";

        public ActivityRepo(IRestClient client) : base(client)
        {
        }

        public override string Resource { get; } = resource;
    }
}
