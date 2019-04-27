using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrenteArpents.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenuEntry : ContentView
    {
        Page pageCache;

        public MasterMenuEntry()
        {
            InitializeComponent();
            AddTapHandler();
        }

        private void AddTapHandler()
        {
            GestureRecognizers.Add(GetTapGestureRecognizer());
        }

        private TapGestureRecognizer GetTapGestureRecognizer()
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTapped;

            return tapGestureRecognizer;
        }

        private void OnTapped(object sender, EventArgs e)
        {
            if (MasterDetailPage.Detail.GetType() == PageType)
            {
                MasterDetailPage.IsPresented = false;
                return;
            }

            if (pageCache == null)
            {
                pageCache = GetPage() ?? throw new InvalidOperationException("Couldn't create a Page.");
            }

            MasterDetailPage.Detail = pageCache;
            MasterDetailPage.IsPresented = false;
        }

        private Page GetPage()
        {
            if (PageType == null)
            {
                throw new InvalidOperationException("PageType is null.");
            }

            Page page = (Page)Activator.CreateInstance(PageType);
            return new NavigationPage(page);
        }

        private MasterDetailPage MasterDetailPage
        {
            get
            {
                return Application.Current.MainPage as MasterDetailPage;
            }
        }

        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(MasterMenuEntry), null);

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(MasterMenuEntry), null);

        public static readonly BindableProperty PageTypeProperty =
            BindableProperty.Create(nameof(PageType), typeof(Type), typeof(MasterMenuEntry), null, propertyChanged: OnPageTypeChanged);

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public Type PageType
        {
            get { return (Type)GetValue(PageTypeProperty); }
            set { SetValue(PageTypeProperty, value); }
        }

        private static void OnPageTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is MasterMenuEntry entry)
            {
                entry.pageCache = null;
            }
        }
    }
}