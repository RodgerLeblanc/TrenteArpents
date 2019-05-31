using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public class HeartRepo : BaseAzureRepo<Email>
    {
        public HeartRepo(IRestClient client, AzureConfiguration configuration) : base(client, configuration)
        {
        }

        public override string GetResource() => "api/";
    }
}
