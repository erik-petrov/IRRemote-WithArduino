using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRemote_WithBM_10.Services;
using XamarinRemote_WithBM_10.Views;

namespace XamarinRemote_WithBM_10
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
