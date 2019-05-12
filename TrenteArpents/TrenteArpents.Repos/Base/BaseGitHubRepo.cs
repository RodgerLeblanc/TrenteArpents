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
        public BaseGitHubRepo(IRestClient client, IGitHubConfiguration configuration) : base(client)
        {
            client.BaseUrl = configuration.BaseUrl;
        }
    }
}
