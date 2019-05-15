using RestSharp;
using System;
using System.Collections.Generic;

namespace TrenteArpents.Repos
{
    public class GitHubConfiguration : IRepoConfiguration
    {
        public Uri BaseUrl { get => new Uri("https://rodgerleblanc.github.io/"); }
        public IEnumerable<Method> SupportedMethods { get; } = new List<Method> { Method.GET };
    }
}
