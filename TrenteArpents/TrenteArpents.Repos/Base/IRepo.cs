using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public interface IRepo<TModel>
        where TModel : IModel, new()
    {
        IRestClient RestClient { get; }

        Task<TModel> GetAsync(int id);
        Task<IEnumerable<TModel>> GetAsync();
    }
}
