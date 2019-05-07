using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public class PhotoRepo : BaseGitHubRepo<Photo>
    {
        private const string resource = "TrenteArpents/Photos/photos.json";

        public PhotoRepo(IRestClient client) : base(client)
        {
        }

        public override string Resource { get; } = resource;
    }
}
