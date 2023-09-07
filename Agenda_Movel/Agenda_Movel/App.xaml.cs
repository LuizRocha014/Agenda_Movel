using Agenda_Movel.View;
using Syncfusion.Licensing;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda_Movel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NGaF1cWGhIfkxyWmFZfV1gc19HZVZVRGY/P1ZhSXxQdkxjXX5XcXxQQmNVVE0=");
            MainPage =  new NavigationPage(new NovoMenuPrincipal());
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
