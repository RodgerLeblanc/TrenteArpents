﻿using FluentAssertions;
using Moq;
using RestSharp;
using SimpleInjector;
using System.Threading.Tasks;
using TrenteArpents.Models;
using TrenteArpents.Repos;
using Xunit;

namespace TrenteArpents.Tests.Repos
{
    public class ActivityRepoTests
    {
        private Container container;

        public ActivityRepoTests()
        {
            Setup();
        }

        [Fact]
        public async Task GetAsync_ResultShouldNotBeEmpty()
        {
            var repo = container.GetInstance<IRepo<Activity>>();

            var result = await repo.GetAsync();

            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetAsyncWithId_ResultShouldNotBeNull()
        {
            var repo = container.GetInstance<IRepo<Activity>>();

            var result = await repo.GetAsync(1);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAsyncWithInvalidId_ResultShouldBeNull()
        {
            var repo = container.GetInstance<IRepo<Activity>>();

            var result = await repo.GetAsync(-1);

            result.Should().BeNull();
        }

        private void Setup()
        {
            container = new Container();

            container.Register(() => new Mock<IRestClient>().Object);
            container.Register<IRepoConfiguration, GitHubConfiguration>();
            container.Register<IRepo<Activity>, ActivityRepoMock>();

            container.Verify();
        }
    }
}
