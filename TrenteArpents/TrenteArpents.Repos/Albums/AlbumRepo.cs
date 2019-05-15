using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public class AlbumRepo : BaseGitHubRepo<Album>
    {
        public AlbumRepo(IRestClient client, IGitHubConfiguration configuration) : base(client, configuration)
        {
        }

        public override string GetResource() => "TrenteArpents/Albums/albums.json";
    }
}
