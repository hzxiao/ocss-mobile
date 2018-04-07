using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ocssmobile.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                username = usernameEntry.Text,
                password = passwordEntry.Text
            };

            //var isValid = AreCredentialsCorrect (user);
            //if (isValid) {
            //    //App.IsUserLoggedIn = true;
            //    Navigation.InsertPageBefore (new MainPage (), this);
            //    await Navigation.PopAsync ();
            //} else {
            //    messageLabel.Text = "Login failed";
            //    passwordEntry.Text = string.Empty;
            //}
            var r = await HttpUtil.Instance.PostAsync("/login", user);
            if (r.code != 0)
            {
                await DisplayAlert("", r.msg, "OK");
                return;
            }

            var u = r.GetDict("user");
            System.Diagnostics.Debug.WriteLine(JsonUtil.ToString(u));

            if (u["role"] as Int64? != 3)
            {
                await DisplayAlert("", "当前账号不是学生账号", "OK");
                return;
            }

            App.Current.Properties["user"] = u;
            App.Current.Properties["token"] = u["token"];

            //await Navigation.PushAsync(new MainPage());
            if (Device.RuntimePlatform == Device.iOS)
            {
                App.Current.MainPage = new MainPage();
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
        }

    }
}
