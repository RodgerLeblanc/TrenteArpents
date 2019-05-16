using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public abstract class BaseRepo<TModel> : IRepo<TModel>
        where TModel : IModel, new()
    {
        public BaseRepo(IRestClient client, IRepoConfiguration configuration)
        {
            RestClient = client;
            Configuration = configuration;

            client.BaseUrl = configuration.BaseUrl;
        }

        private IRepoConfiguration Configuration { get; }
        public IRestClient RestClient { get; }

        public abstract string GetResource();

        public virtual async Task<TModel> GetAsync(int id)
        {
            if (!IsSupported(Method.GET))
            {
                throw new NotSupportedException();
            }

            try
            {
                IEnumerable<TModel> items = await GetAsync(m => m.Id == id);
                return items.FirstOrDefault();
            }
            catch (Exception)
            {
                return default;
            }
        }

        public virtual async Task<IEnumerable<TModel>> GetAsync(Func<TModel, bool> predicate)
        {
            if (!IsSupported(Method.GET))
            {
                throw new NotSupportedException();
            }

            try
            {
                var items = await GetAsync();

                if (items == null)
                {
                    return Enumerable.Empty<TModel>();
                }

                return items
                    .Where(predicate)
                    .ToList();
            }
            catch (Exception)
            {
                return Enumerable.Empty<TModel>();
            }
        }

        public virtual async Task<IEnumerable<TModel>> GetAsync()
        {
            if (!IsSupported(Method.GET))
            {
                throw new NotSupportedException();
            }

            try
            {
                var request = new RestRequest(GetResource(), DataFormat.Json);
                return await RestClient.GetAsync<List<TModel>>(request);
            }
            catch (Exception)
            {
                return Enumerable.Empty<TModel>();
            }
        }

        public virtual async Task<TResponse> PostAsync<TResponse>(TModel model)
            where TResponse : new()
        {
            if (!IsSupported(Method.POST))
            {
                throw new NotSupportedException();
            }

            try
            {
                var request = new RestRequest(GetResource(), DataFormat.Json).AddJsonBody(model);
                return await RestClient.PostAsync<TResponse>(request);
            }
            catch (Exception)
            {
                return default;
            }
        }

        private bool IsSupported(Method method)
        {
            return Configuration.SupportedMethods.Contains(method);
        }
    }
}
