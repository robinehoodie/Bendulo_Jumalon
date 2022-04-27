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
    public partial class ForgotPassword : ContentPage
    {
        ResetPassEmail x = new ResetPassEmail();        
        public ForgotPassword()
        {
            InitializeComponent();
            BindingContext = x;
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Black;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            x.email = "";
        }
        private void ResetPassClicked(object sender, EventArgs e)
        {
            string mail = x.email;
            
            if (mail == "")
            {
                var frame1 = loginmailframe;
                frame1.BorderColor = Color.Red;
                DisplayAlert("Error", "Missing Field", "OK");

            }
            else
            {
                indicatorLog.IsVisible = true;
                indicatorLog.IsRunning = true;
                DisplayAlert("Success", "Email has been sent to your email address", "OK");
                
            }
        }
        private void emailFocusedevent(object sender, FocusEventArgs e)
        {
            var frame1 = loginmailframe;
            if (frame1.BorderColor == Color.Red)
            {
                frame1.BorderColor = Color.Black;

            }

        }

    }
    public class ResetPassEmail : INotifyPropertyChanged
    {
        string _email { get; set; } = "";  


        public string email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(email)); }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}