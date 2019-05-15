using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public abstract class BaseAzureRepo<TModel> : BaseRepo<TModel>
        where TModel : IModel, new()
    {
        public BaseAzureRepo(IRestClient client, AzureConfiguration configuration) : base(client, configuration)
        {
        }
    }
}
