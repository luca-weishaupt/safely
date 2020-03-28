using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safely.Model;
using Safely.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safely.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Init();
        }

        void Init()
        {

            BackgroundColor = Constants.BackgroundColor;
         
        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            if (Entry_Email.Text != null)
            {
                var userFromDatabase = await firebaseHelper.GetUser(Entry_Email.Text);
                if (userFromDatabase != null)
                {
                    if (Entry_Password.Text.Equals(userFromDatabase.Password.ToString()))
                    {
                        await DisplayAlert("Login", "Login Success", "Ok");
                        return;
                    }
                }
            }

            await DisplayAlert("Login", "Login Failed, wrong email or password", "Ok");
            Application.Current.Properties["email"] = Entry_Email.Text;
            await Navigation.PushAsync(new StatusPage());
        }

        void RegisterPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}