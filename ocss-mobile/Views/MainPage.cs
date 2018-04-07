using System;

using Xamarin.Forms;

using ocssmobile.Views;
namespace ocssmobile
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page selectCoursePage, myCoursePage, noticePage, profilePage, itemsPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    selectCoursePage = new NavigationPage(new SelectCoursePage())
                    {
                        Title = "选课"
                    };

                    myCoursePage = new NavigationPage(new MyCoursePage())
                    {
                        Title = "课程"
                    };

                    noticePage = new NavigationPage(new NoticePage())
                    {
                        Title = "通知"
                    };

                    profilePage = new NavigationPage(new ProfilePage())
                    {
                        Title = "我的"
                    };

                    itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    selectCoursePage.Icon = "tab_feed.png";
                    myCoursePage.Icon = "tab_feed.png";
                    noticePage.Icon = "tab_feed.png";
                    profilePage.Icon = "tab_feed.png";

                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    selectCoursePage = new SelectCoursePage()
                    {
                        Title = "选课"
                    };

                    myCoursePage = new MyCoursePage()
                    {
                        Title = "课程"
                    };

                    noticePage = new NoticePage()
                    {
                        Title = "通知"
                    };

                    profilePage = new ProfilePage()
                    {
                        Title = "我的"
                    };

                    itemsPage = new ItemsPage()
                    {
                        Title = "Browse"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(selectCoursePage);
            Children.Add(myCoursePage);
            Children.Add(noticePage);
            Children.Add(profilePage);


            Children.Add(itemsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;

            if (!App.Current.Properties.ContainsKey("token"))
            {
                Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new LoginPage()));
            }
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
