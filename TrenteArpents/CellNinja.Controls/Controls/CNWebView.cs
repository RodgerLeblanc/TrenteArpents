using Xamarin.Forms;

namespace CellNinja.Controls
{
    public class CNWebView : WebView
    {
        public CNWebView()
        {
            Navigating += OnNavigating;
            Navigated += OnNavigated;
        }

        protected virtual void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            IsNavigating = true;
        }

        protected virtual void OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            IsNavigating = false;
        }

        private static readonly BindablePropertyKey IsNavigatingPropertyKey =
            BindableProperty.CreateReadOnly(
                nameof(IsNavigating),
                typeof(bool),
                typeof(CNWebView),
                false);

        public static readonly BindableProperty IsNavigatingProperty = IsNavigatingPropertyKey.BindableProperty;

        public bool IsNavigating
        {
            get { return (bool)GetValue(IsNavigatingProperty); }
            private set { SetValue(IsNavigatingPropertyKey, value); }
        }
    }
}
