using System;
using System.Collections.Generic;

using Xamarin.Forms;

using ocssmobile;
namespace ocssmobile.Views
{
    public partial class ProfilePage : ContentPage
    {
        ProfileViewModel viewModel;

        public ProfilePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProfileViewModel();
        }
    }
}
