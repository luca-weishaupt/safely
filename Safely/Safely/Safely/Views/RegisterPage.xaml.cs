using Safely.Data;
using Safely.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safely.Views;
using Safely.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safely
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public RegisterPage()
        {
            InitializeComponent();
            Init();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
        }
         async void RegisterProcedure(object sender, EventArgs e)
        {
            
            if (RegisterEmail.Text.Equals(null) || RegisterPassword.Text.Equals(null))
            {
                await DisplayAlert("Register", "Registration failed, You must enter both an email and a password", "Ok");
                return;
            }
            string email = RegisterEmail.Text;
            var existingUser = await firebaseHelper.GetUser(email);
            if (existingUser != null && existingUser.Email.Equals(email))
            {
                await DisplayAlert("Register", "Register failed, a user with the same email address already exists", "Ok");
                return;
            }
            await firebaseHelper.AddUser(email, RegisterPassword.Text);
            await DisplayAlert("Register", "Register Succeeded, your account has been created!", "Ok");
            Application.Current.Properties["email"] = email;
            await Navigation.PushAsync(new StatusPage());
        }

        void BacktoSignup(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}