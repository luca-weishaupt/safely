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
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Email.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginInconHeight;
            LoginIcon.WidthRequest = Constants.LoginIconWidth;
            Entry_Email.BackgroundColor = Constants.BoxColor;
            Entry_Password.BackgroundColor = Constants.BoxColor;
        }

        void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Email.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login Success", "Ok");
            }
            else
            {
                DisplayAlert("Login", "Login Failed, empty email or password", "Ok");
            }
        }
    }
}