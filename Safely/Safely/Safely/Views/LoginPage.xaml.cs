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
            Init();
            NavigationPage.SetHasNavigationBar(this, false);
            
            
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
                        Application.Current.Properties["email"] = Entry_Email.Text;
                        Application.Current.Properties["stayLoggedIn"] = StayLoggedIn.IsToggled;
                        await Navigation.PushAsync(new StatusPage());
                        return;
                    }
                }
            }

            await DisplayAlert("Login", "Login failed, wrong email or password", "Ok");
        }

        void RegisterPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}