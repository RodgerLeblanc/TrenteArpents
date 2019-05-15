using RestSharp;
using System;
using System.Collections.Generic;

namespace TrenteArpents.Repos
{
    public interface IRepoConfiguration
    {
        Uri BaseUrl { get; }
        IEnumerable<Method> SupportedMethods { get; }
    }
}
