using Safely.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safely.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatusPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public StatusPage()
        {
            InitializeComponent();
        }

        async void UpdateUserStatus(object sender, EventArgs e)
        {
            string email = null;
            if (Application.Current.Properties.ContainsKey("email"))
            {
                email = (string) Application.Current.Properties["email"];
            } else
            {
                return;
            }

            Button b = (Button)sender;
            if (b.Text.Equals("Healthy")) {
                await firebaseHelper.UpdateStatus(email, Model.User.StatusEnum.Healthy);
            } else if (b.Text.Equals("Symptomatic"))
            {
                await firebaseHelper.UpdateStatus(email, Model.User.StatusEnum.Symptomatic);
            } else if (b.Text.Equals("Diagnosed"))
            {
                await firebaseHelper.UpdateStatus(email, Model.User.StatusEnum.Diagnosed);
            } else if (b.Text.Equals("Recovered"))
            {
                await firebaseHelper.UpdateStatus(email, Model.User.StatusEnum.Recovered);
            }
        }
    }
}