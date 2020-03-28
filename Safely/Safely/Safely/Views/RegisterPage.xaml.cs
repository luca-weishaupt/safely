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
        public RegisterPage()
        {
            InitializeComponent();
        }

         async void RegisterProcedure(object sender, EventArgs e)
        {
            if (RegisterEmail.Text.Equals("") || RegisterPassword.Equals(""))
            {
                await DisplayAlert("Login", "Login Success", "Ok");
                return;
            }

        }
    }
}