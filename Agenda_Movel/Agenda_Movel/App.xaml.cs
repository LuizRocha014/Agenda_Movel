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
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF5cWWJCfEx3WmFZfVpgcF9CYVZTTGY/P1ZhSXxXdkRjW35YdHVXT2VbU0I=");
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
