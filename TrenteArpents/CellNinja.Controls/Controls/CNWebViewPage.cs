using System.Threading.Tasks;
using Xamarin.Forms;

namespace CellNinja.Controls
{
    public class CNWebViewPage : ContentPage
    {
        private Grid _grid;
        private ActivityIndicator _activityIndicator;
        private CNWebView _webView;

        public CNWebViewPage()
        {
            _grid = new Grid();
            _activityIndicator = new ActivityIndicator
            {
                IsRunning = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            _grid.Children.Add(_activityIndicator);

            Content = _grid;
        }

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(nameof(Source), typeof(WebViewSource), typeof(CNWebViewPage), null);

        public WebViewSource Source
        {
            get { return (WebViewSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly BindableProperty CreationDelayProperty =
            BindableProperty.Create(nameof(CreationDelay), typeof(int), typeof(CNWebViewPage), 100);

        public int CreationDelay
        {
            get { return (int)GetValue(CreationDelayProperty); }
            set { SetValue(CreationDelayProperty, value); }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (WebViewAlreadyCreated())
            {
                return;
            }

            await CreateWebViewAfterDelay(CreationDelay);
        }

        private bool WebViewAlreadyCreated()
        {
            return _webView != null;
        }

        private async Task CreateWebViewAfterDelay(int delay)
        {
            await Task.Delay(delay);

            _webView = new CNWebView();

            _grid.Children.Insert(0, _webView);

            _webView.SetBinding(
                CNWebView.SourceProperty,
                new Binding(nameof(Source)) { Source = this, Mode = BindingMode.OneWay });

            _activityIndicator.SetBinding(
                ActivityIndicator.IsRunningProperty,
                new Binding(nameof(CNWebView.IsNavigating)) { Source = _webView, Mode = BindingMode.OneWay });

            _activityIndicator.SetBinding(
                ActivityIndicator.IsVisibleProperty,
                new Binding(nameof(CNWebView.IsNavigating)) { Source = _webView, Mode = BindingMode.OneWay });
        }
    }
}
