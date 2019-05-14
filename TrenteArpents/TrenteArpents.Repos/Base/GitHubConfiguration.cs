using System;

namespace TrenteArpents.Repos
{
    public class GitHubConfiguration : IGitHubConfiguration
    {
        public Uri BaseUrl { get => new Uri("https://rodgerleblanc.github.io/"); }
    }
}
