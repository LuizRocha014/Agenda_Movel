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
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NGaF1cWGhAYVBpR2NbfE54flVPal1SVBYiSV9jS31TfkVnW39fcnVTT2NaVA==");
            MainPage =  new NavigationPage(new MenuPrincipalPage());
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
