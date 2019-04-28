using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public abstract class BaseGitHubRepo<TModel> : BaseRepo<TModel>
        where TModel : IModel, new()
    {
        private const string gitHubBaseUrl = "https://rodgerleblanc.github.io/";

        public BaseGitHubRepo(IRestClient client) : base(client)
        {
            client.BaseUrl = new Uri(gitHubBaseUrl);
        }
    }
}
