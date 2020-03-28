using Safely.Data;
using Safely.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

         async void RegisterProcedure(object sender, EventArgs e)
        {
            if (RegisterEmail.Text.Equals("") || RegisterPassword.Text.Equals(""))
            {
                await DisplayAlert("Register", "Register Failed, You must enter both an email and a password", "Ok");
                return;
            }
            string email = RegisterEmail.Text;
            var existingUser = firebaseHelper.GetUser(email);
            if (existingUser != null)
            {
                await DisplayAlert("Register", "Register failed, a user with the same email address already exists", "Ok");
                return;
            }
            await firebaseHelper.AddUser(email, RegisterPassword.Text);
        }
    }
}