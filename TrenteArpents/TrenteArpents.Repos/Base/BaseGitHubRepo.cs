using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public abstract class BaseGitHubRepo<TModel> : BaseRepo<TModel>
        where TModel : IModel, new()
    {
        public BaseGitHubRepo(IRestClient client, GitHubConfiguration configuration) : base(client, configuration)
        {
        }
    }
}
