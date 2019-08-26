using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public class HeartRepo : BaseAzureRepo<HeartInfo>
    {
        public HeartRepo(IRestClient client, AzureConfiguration configuration) : base(client, configuration)
        {
        }

        public override string GetResource() => "api/";
    }
}
