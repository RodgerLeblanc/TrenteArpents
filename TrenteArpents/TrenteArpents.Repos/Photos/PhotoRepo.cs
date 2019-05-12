using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public class PhotoRepo : BaseGitHubRepo<Photo>
    {
        public PhotoRepo(IRestClient client, IGitHubConfiguration configuration) : base(client, configuration)
        {
        }

        public override string GetResource() => "ServerFiles/Photos/photos.json";
    }
}
