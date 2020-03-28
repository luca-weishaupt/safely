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
        public RegisterPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
        }
         async void RegisterProcedure(object sender, EventArgs e)
        {
            if (RegisterEmail.Text.Equals("") || RegisterPassword.Equals(""))
            {
                await DisplayAlert("Login", "Login Success", "Ok");
                return;
            }

        }

        void BacktoSignup(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}