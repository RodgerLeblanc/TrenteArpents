﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrenteArpents.Models;
using TrenteArpents.Repos;

namespace TrenteArpents.Tests.Repos
{
    public class ActivityRepoMock : BaseRepo<Activity>
    {
        public ActivityRepoMock(IRestClient client, IRepoConfiguration repoConfiguration) : base(client, repoConfiguration)
        {
        }

        public override string GetResource() => String.Empty;

        public override Task<IEnumerable<Activity>> GetAsync()
        {
            DateTime partyStartTime = new DateTime(2019, 8, 17, 10, 0, 0);

            IEnumerable<Activity> activities = Enumerable
                .Range(1, 10)
                .Select(i => new Activity
                {
                    Id = i,
                    Name = $"Sponsor #{i}",
                    Description = $"Description #{i}",
                    Time = "10:00 - 16:30",
                    ImageUrl = new Uri($"https://via.placeholder.com/150?text={i}"),
                })
                .ToList();

            return Task.FromResult(activities);
        }
    }
}
