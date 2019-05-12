using System;

namespace TrenteArpents.Repos
{
    public class GitHubConfiguration : IGitHubConfiguration
    {
        public Uri BaseUrl
        {
            get => new Uri("https://raw.githubusercontent.com/RodgerLeblanc/TrenteArpents/develop/");
        }
    }
}
