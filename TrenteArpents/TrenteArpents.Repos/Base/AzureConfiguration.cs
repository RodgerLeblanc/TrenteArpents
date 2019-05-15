using RestSharp;
using System;
using System.Collections.Generic;

namespace TrenteArpents.Repos
{
    public class AzureConfiguration : IRepoConfiguration
    {
        public Uri BaseUrl { get => new Uri("https://trentearpentsemail.azurewebsites.net/"); }
        public IEnumerable<Method> SupportedMethods { get; } = new List<Method> { Method.POST };
    }
}
