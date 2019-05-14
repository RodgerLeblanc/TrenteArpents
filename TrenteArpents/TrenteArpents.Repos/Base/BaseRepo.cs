using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return (await GetAsync(m => m.Id == id)).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<TModel>> GetAsync(Func<TModel, bool> predicate)
        {
            var items = await GetAsync();

            return items
                .Where(predicate)
                .ToList();
        }

        public virtual async Task<IEnumerable<TModel>> GetAsync()
        {
            var request = new RestRequest(GetResource(), DataFormat.Json);
            return await RestClient.GetAsync<List<TModel>>(request);
        }
    }
}
