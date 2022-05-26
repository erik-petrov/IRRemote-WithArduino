using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinRemote_WithBM_10.ViewModels;
using XamarinRemote_WithBM_10.Views;

namespace XamarinRemote_WithBM_10
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
