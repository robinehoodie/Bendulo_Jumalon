using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatappBenduloJumalon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        RegisterEntries x = new RegisterEntries();
       
        public Register()
        {

            InitializeComponent();
            BindingContext = x;
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
        }
        //to delay process temp code

       
        private void emailFocusedevent(object sender, FocusEventArgs e)
        {
            var frame1 = emailframe;
            if (frame1.BorderColor == Color.Red)
            {
                frame1.BorderColor = Color.Black;
            }

        }
        private void usernameFocusedevent(object sender, FocusEventArgs e)
        {
            var frame1 = usernameframe;
            if (frame1.BorderColor == Color.Red)
            {
                frame1.BorderColor = Color.Black;
            }

        }
        private void confirmpassFocusedevent(object sender, FocusEventArgs e)
        {
            var frame1 = confirmpassframe;
            if (frame1.BorderColor == Color.Red)
            {
                frame1.BorderColor = Color.Black;
            }

        }
        private void passFocusedevent(object sender, FocusEventArgs e)
        {
            var frame1 = passframe;
            if (frame1.BorderColor == Color.Red)
            {
                frame1.BorderColor = Color.Black;
            }

        }
        private void ReturntoMain(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        

        private void CustomButton_Clicked(object sender, EventArgs e)
        {
            if (x.email == "")
            {
                var frame1 = emailframe;
                frame1.BorderColor = Color.Red;

            }
            if (x.confirmpass == "")
            {
                var frame1 = confirmpassframe;
                frame1.BorderColor = Color.Red;
            }
            if (x.username == "")
            {
                var frame1 = usernameframe;
                frame1.BorderColor = Color.Red;
            }
            if (x.pass == "")
            {
                var frame1 = passframe;
                frame1.BorderColor = Color.Red;
            }
            if (x.pass == "" || x.email == "" || x.confirmpass == "" || x.username == "")
            {
                DisplayAlert("Error", "Missing Fields", "OK");
            }
            else
            {
                if (x.confirmpass == x.pass)
                    DisplayAlert("Success", "Sign Up Successful. Verification email sent", "Okay");
                else
                {
                    DisplayAlert("Error", "Your Passwords Do not Match", "Okay");
                    confirmpassframe.BorderColor = Color.Red;
                    passframe.BorderColor = Color.Red;
                }
            }
        }
    }
    public class RegisterEntries : INotifyPropertyChanged
    {
        string _email { get; set; } = "";
        string _pass { get; set; } = "";

        string _user { get; set; } = "";
        string _confirmpass { get; set; } = "";

        public string email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(email)); }
        }
        public string username
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(nameof(username)); }
        }
        public string pass
        {
            get { return _pass; }
            set { _pass = value; OnPropertyChanged(nameof(pass)); }
        }
        public string confirmpass
        {
            get { return _confirmpass; }
            set { _confirmpass = value; OnPropertyChanged(nameof(confirmpass)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
