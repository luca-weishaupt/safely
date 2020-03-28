using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safely.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safely.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login Success", "Ok");
            }
            else
            {
                DisplayAlert("Login", "Login Failed, empty username or password", "Ok");
            }
        }
    }
}