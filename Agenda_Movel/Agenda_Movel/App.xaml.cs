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
            SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHFqVkNrWU5Gf0BAXWFKblV8R2tTellgFChNYlxTR3ZbQFRiQX1XdU1hWX9Z;Mgo+DSMBPh8sVXJ1S0d+X1RPc0BAVHxLflF1VWVTfVZ6cVJWACFaRnZdQV1nS3dSfkZnWndccXBS;ORg4AjUWIQA/Gnt2VFhhQlJBfVpdX2pWfFN0RnNfdVx4flBBcDwsT3RfQF5jTXxad01gXXxWcnZcQQ==;MTg3Nzc5NUAzMjMxMmUzMTJlMzMzNUFESzR2L2FyZGNKaEhBcmg4dXphWWpaSEJQTkVBRjBzRVJHb0haeEtGSGM9;MTg3Nzc5NkAzMjMxMmUzMTJlMzMzNVhTZW1zcUVDQkdZNC9QRDY4QmlVYlV4TXpFUDBLNjZZZU5telpUZytpVVU9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RHQmFAYVF2R2BJeVRyfF9DZ0wxOX1dQl9gSXpRf0RrWntdeHZdQWc=;MTg3Nzc5OEAzMjMxMmUzMTJlMzMzNU9Yc1lKZFRwMjAxV25hdEtIelYvbkEyRmdFeEpYYkJSSUpwN04zVkVMUGc9;MTg3Nzc5OUAzMjMxMmUzMTJlMzMzNVg0UXlQK1prajV3SXo4MWtoSGxydkdDMnBpZUcweDAxZXNlQmNDYmZqVlk9;Mgo+DSMBMAY9C3t2VFhhQlJBfVpdX2pWfFN0RnNfdVx4flBBcDwsT3RfQF5jTXxad01gXXxWc3FUQQ==;MTg3NzgwMUAzMjMxMmUzMTJlMzMzNVozMklORE84V00yY1Z0dCtsOTVUNWFxRVBmTVdUbGJBWStvV0RFSk8xbFk9;MTg3NzgwMkAzMjMxMmUzMTJlMzMzNVQ2dXQwWkdMcHplbEM0eHBlKzUzUlpsV1gvNDhDUE9mSStHQUZuU29OOXM9;MTg3NzgwM0AzMjMxMmUzMTJlMzMzNU9Yc1lKZFRwMjAxV25hdEtIelYvbkEyRmdFeEpYYkJSSUpwN04zVkVMUGc9");
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
