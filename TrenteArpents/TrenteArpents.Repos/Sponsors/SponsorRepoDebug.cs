using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TrenteArpents.Models;

namespace TrenteArpents.Repos
{
    public class SponsorRepoDebug : IRepo<Sponsor>
    {
        public SponsorRepoDebug()
        {
        }

        public IRestClient RestClient { get; }

        public async Task<Sponsor> GetAsync(int id)
        {
            return (await GetAsync()).First();
        }

        public Task<IEnumerable<Sponsor>> GetAsync()
        {
            string json = @"[{
        ""id"": 1,
        ""name"": ""Domaine des 30 Arpents"",
        ""imageUrl"": ""https://i.postimg.cc/nLyqJ7pD/domaine-Des30-Arpents.png"",
        ""sponsorType"": 0,
        ""promoUrl"": ""http://30arpents.com/""
    },
    {
        ""id"": 2,
        ""name"": ""Groupe Doyon"",
        ""imageUrl"": ""https://i.postimg.cc/NG7m35VK/groupe-Doyon.png"",
        ""sponsorType"": 0,
        ""promoUrl"": ""http://groupedoyon.com/""
    },
    {
        ""id"": 3,
        ""name"": ""Marché Raynald Giguère"",
        ""imageUrl"": ""https://i.postimg.cc/FH1SkGKS/raynald-Giguere.png"",
        ""sponsorType"": 0,
        ""promoUrl"": ""https://www.iga.net/fr/recherche_de_magasin/magasin/8035-marche-raynald-giguere-inc-""
    },
    {
        ""id"": 4,
        ""name"": ""Desjardins"",
        ""imageUrl"": ""https://i.postimg.cc/WbfLTmfz/desjardins.png"",
        ""sponsorType"": 0,
        ""promoUrl"": ""https://www.desjardins.com/""
    },
    {
        ""id"": 5,
        ""name"": ""Groupe Doyon"",
        ""imageUrl"": ""https://i.postimg.cc/NG7m35VK/groupe-Doyon.png"",
        ""sponsorType"": 0,
        ""promoUrl"": ""http://groupedoyon.com/""
    },
    {
        ""id"": 6,
        ""name"": ""Marché Raynald Giguère"",
        ""imageUrl"": ""https://i.postimg.cc/FH1SkGKS/raynald-Giguere.png"",
        ""sponsorType"": 0,
        ""promoUrl"": ""https://www.iga.net/fr/recherche_de_magasin/magasin/8035-marche-raynald-giguere-inc-""
    },
    {
        ""id"": 7,
        ""name"": ""La Capitale en Fête"",
        ""imageUrl"": ""https://i.postimg.cc/nLyqJ7pD/domaine-Des30-Arpents.png"",
        ""sponsorType"": 0,
        ""promoUrl"": ""http://30arpents.com/""
    },
    {
        ""id"": 8,
        ""name"": ""Groupe Doyon"",
        ""imageUrl"": ""https://i.postimg.cc/NG7m35VK/groupe-Doyon.png"",
        ""sponsorType"": 0,
        ""promoUrl"": ""http://groupedoyon.com/""
    },
    {
        ""id"": 9,
        ""name"": ""Marché Raynald Giguère"",
        ""imageUrl"": ""https://i.postimg.cc/FH1SkGKS/raynald-Giguere.png"",
        ""sponsorType"": 0,
        ""promoUrl"": ""https://www.iga.net/fr/recherche_de_magasin/magasin/8035-marche-raynald-giguere-inc-""
    }
]";

            IEnumerable<Sponsor> items = JsonConvert.DeserializeObject<List<Sponsor>>(json);
            return Task.FromResult(items);
        }
    }
}
