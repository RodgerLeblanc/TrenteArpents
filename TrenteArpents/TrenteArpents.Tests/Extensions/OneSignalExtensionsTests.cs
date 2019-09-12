using AutoFixture.Xunit2;
using Com.OneSignal.Abstractions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using TrenteArpents.Extensions;
using Xunit;

namespace TrenteArpents.Tests.Extensions
{
    public class OneSignalExtensionsTests
    {
        public class OSNotificationTests
        {
            [Fact]
            public void ToDictionary_Null_ShouldThrowArgumentNullException()
            {
                OSNotification sut = null;

                Action action = () => sut.ToDictionary();

                action.Should().Throw<ArgumentNullException>();
            }

            [Theory, AutoData]
            public void ToDictionary_WhenCalled_ShouldContainOSNotification(OSNotification sut)
            {
                string className = sut.GetType().Name;

                IDictionary<string, string> result = sut.ToDictionary();

                result.Should().HaveCount(1);
                result.Should().ContainKey(className);
                result[className].Should().NotBeNullOrEmpty();
            }
        }

        public class OSNotificationOpenedResultTests
        {
            [Fact]
            public void ToDictionary_Null_ShouldThrowArgumentNullException()
            {
                OSNotificationOpenedResult sut = null;

                Action action = () => sut.ToDictionary();

                action.Should().Throw<ArgumentNullException>();
            }

            [Theory, AutoData]
            public void ToDictionary_WhenCalled_ShouldContainOSNotificationOpenedResult(OSNotificationOpenedResult sut)
            {
                string className = sut.GetType().Name;

                IDictionary<string, string> result = sut.ToDictionary();

                result.Should().HaveCount(1);
                result.Should().ContainKey(className);
                result[className].Should().NotBeNullOrEmpty();
            }
        }

        public class OSInAppMessageActionTests
        {
            [Fact]
            public void ToDictionary_Null_ShouldThrowArgumentNullException()
            {
                OSInAppMessageAction sut = null;

                Action action = () => sut.ToDictionary();

                action.Should().Throw<ArgumentNullException>();
            }

            [Theory, AutoData]
            public void ToDictionary_WhenCalled_ShouldContainOSInAppMessageAction(OSInAppMessageAction sut)
            {
                string className = sut.GetType().Name;

                IDictionary<string, string> result = sut.ToDictionary();

                result.Should().HaveCount(1);
                result.Should().ContainKey(className);
                result[className].Should().NotBeNullOrEmpty();
            }
        }
    }
}
