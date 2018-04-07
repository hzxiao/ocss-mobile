using System;
using System.Collections.Generic;

using Xamarin.Forms;

using ocssmobile;

namespace ocssmobile.Views
{
    public partial class NoticePage : ContentPage
    {
        NoticeViewModel viewModel;
        public NoticePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NoticeViewModel();
        }
    }
}
