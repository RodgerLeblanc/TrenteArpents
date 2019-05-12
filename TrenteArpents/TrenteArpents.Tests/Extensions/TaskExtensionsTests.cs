using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using TrenteArpents.Extensions;
using TrenteArpents.ViewModels;
using Xunit;

namespace TrenteArpents.Tests.Extensions
{
    public class TaskExtensionsTests
    {
        [Fact]
        public void SetIsBusy_WithNullTask_ShouldThrowArgumentNullException()
        {
            Task sut = null;
            var mock = new Mock<IBusyViewModel>();

            Func<Task> action = async () => await sut.SetIsBusy(mock.Object);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetIsBusyGeneric_WithNullTask_ShouldThrowArgumentNullException()
        {
            Task<string> sut = null;
            var mock = new Mock<IBusyViewModel>();

            Func<Task> action = async () => await sut.SetIsBusy(mock.Object);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetIsBusy_WithNullViewModel_ShouldThrowArgumentNullException()
        {
            Task sut = Task.Delay(300);

            Func<Task> action = async () => await sut.SetIsBusy(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetIsBusyGeneric_WithNullViewModel_ShouldThrowArgumentNullException()
        {
            Task<string> sut = Task.FromResult(String.Empty);

            Func<Task> action = async () => await sut.SetIsBusy(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetIsBusy_WhenCalled_ShouldSetIsBusyOn()
        {
            Task sut = Task.Delay(300);
            var mock = new Mock<IBusyViewModel>();

            mock.SetupSet(vm => vm.IsBusy = false);

            var result = sut.SetIsBusy(mock.Object);

            mock.VerifySet(vm => vm.IsBusy = true);
        }

        [Fact]
        public void SetIsBusyGeneric_WhenCalled_ShouldSetIsBusyOn()
        {
            Task<string> sut = Task.FromResult(String.Empty);
            var mock = new Mock<IBusyViewModel>();

            mock.SetupSet(vm => vm.IsBusy = false);

            var result = sut.SetIsBusy(mock.Object);

            mock.VerifySet(vm => vm.IsBusy = true);
        }

        [Fact]
        public async Task SetIsBusy_WhenCalled_ShouldSetIsBusyOffWhenDone()
        {
            Task sut = Task.Delay(300);
            var mock = new Mock<IBusyViewModel>();

            mock.SetupSet(vm => vm.IsBusy = false);

            await sut.SetIsBusy(mock.Object);

            mock.Object.IsBusy.Should().Be(false);
        }

        [Fact]
        public async Task SetIsBusyGeneric_WhenCalled_ShouldSetIsBusyOffWhenDone()
        {
            Task<string> sut = Task.FromResult(String.Empty);
            var mock = new Mock<IBusyViewModel>();

            mock.SetupSet(vm => vm.IsBusy = false);

            await sut.SetIsBusy(mock.Object);

            mock.Object.IsBusy.Should().Be(false);
        }
    }
}
