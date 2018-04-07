using System;

using Xamarin.Forms;

using ocssmobile.Views;

namespace ocssmobile
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "http://111.230.242.177:8999";

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (App.Current.Properties.ContainsKey("token"))
            {
                App.Current.Properties.Clear();
            }
            if (Device.RuntimePlatform == Device.iOS)
            {
                Console.WriteLine(App.Current.Properties.ContainsKey("token"));
                if (App.Current.Properties.ContainsKey("token"))
                {
                    MainPage = new MainPage();
                }
                else 
                {
                    MainPage = new LoginPage();
                }
            }
            else
            {
                if (App.Current.Properties.ContainsKey("token"))
                {
                    MainPage = new NavigationPage(new MainPage());
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
            }
        }
    }
}
