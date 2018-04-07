using System;
using System.Collections.Generic;

using Xamarin.Forms;

using ocssmobile;
namespace ocssmobile.Views
{
    public partial class MyCoursePage : ContentPage
    {
        MyCourseViewModel viewModel;
        public MyCoursePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MyCourseViewModel();
        }
    }
}
