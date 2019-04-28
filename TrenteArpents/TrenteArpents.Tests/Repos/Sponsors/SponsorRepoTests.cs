using FluentAssertions;
using Moq;
using RestSharp;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrenteArpents.Models;
using TrenteArpents.Repos;
using Xunit;

namespace TrenteArpents.Tests.Repos
{
    public class SponsorRepoTests
    {
        private Container container;

        public SponsorRepoTests()
        {
            Setup();
        }

        [Fact]
        public async Task GetAsync_ResultShouldNotBeEmpty()
        {
            var repo = container.GetInstance<IRepo<Sponsor>>();

            var result = await repo.GetAsync();

            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetAsyncWithId_ResultShouldNotBeNull()
        {
            var repo = container.GetInstance<IRepo<Sponsor>>();

            var result = await repo.GetAsync(1);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAsyncWithInvalidId_ResultShouldBeNull()
        {
            var repo = container.GetInstance<IRepo<Sponsor>>();

            var result = await repo.GetAsync(-1);

            result.Should().BeNull();
        }

        private void Setup()
        {
            container = new Container();

            container.Register(() => new Mock<IRestClient>().Object);
            container.Register<IRepo<Sponsor>, SponsorRepoMock>();

            container.Verify();
        }
    }
}
