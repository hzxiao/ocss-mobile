using System;
using System.Collections.Generic;

using Xamarin.Forms;

using ocssmobile;

namespace ocssmobile.Views
{
    public partial class SelectCoursePage : ContentPage
    {
        SelectCourseViewModel viewModel;
        
        public SelectCoursePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SelectCourseViewModel();
        }
    }
}
