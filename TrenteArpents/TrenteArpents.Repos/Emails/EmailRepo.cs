using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public class EmailRepo : BaseAzureRepo<Email>
    {
        public EmailRepo(IRestClient client, AzureConfiguration configuration) : base(client, configuration)
        {
        }

        public override string GetResource() => "api/SendEmail";
    }
}
