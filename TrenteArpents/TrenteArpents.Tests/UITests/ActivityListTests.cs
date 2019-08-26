using Xamarin.UITest;
using Xunit;

namespace TrenteArpents.Tests.UITests
{
    public class ActivityListTests
    {
        IApp app;

        public ActivityListTests()
        {
            app = ConfigureApp
                .Android
                .ApkFile("../../../../TrenteArpents.Android/AppStoreReleases/1.2/com.cellninja.TrenteArpents_v9.apk")
                .StartApp();
        }

        [Fact]
        public void Test()
        {
            app.Repl();
        }
    }
}
