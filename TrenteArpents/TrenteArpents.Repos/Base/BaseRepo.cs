using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public abstract class BaseRepo<TModel> : IRepo<TModel>
        where TModel : IModel, new()
    {
        public BaseRepo(IRestClient client)
        {
            RestClient = client;
        }

        public IRestClient RestClient { get; }

        public abstract string GetResource();

        public virtual async Task<TModel> GetAsync(int id)
        {
            //Retrieving the whole list as Get(id) is not available on our server
            var items = await GetAsync();

            return items
                .Where(i => i.Id == id)
                .FirstOrDefault();
        }

        public virtual async Task<IEnumerable<TModel>> GetAsync()
        {
            var request = new RestRequest(GetResource(), DataFormat.Json);
            return await RestClient.GetAsync<List<TModel>>(request);
        }
    }
}
