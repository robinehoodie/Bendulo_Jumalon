using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatappBenduloJumalon
{
    public partial class MainPage : ContentPage
    {
        DataEntries x = new DataEntries();
        List<Acc> accounts = new List<Acc>();
        public MainPage()
        {
           
            InitializeComponent();
            BindingContext = x;
            Acc verifiedacc = new Acc("francis","francisbendulo@gmail.com","123456",true);
            accounts.Add(verifiedacc);
            Acc unverfiedacc = new Acc("Robine Jumalon", "robinecole@gmail.com", "123456", false);
            accounts.Add(unverfiedacc);
        }
        
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            x.email = "";
            x.pass="";
        }
        //to delay process temp code
      
        private void LoginClicked(object sender, EventArgs e)
        {
            string mail=x.email;
            string pass=x.pass;

            indicatorLog.IsVisible = true;
            indicatorLog.IsRunning=true;
            
            if (mail == "")
            {
                var frame1 = loginmailframe;
                frame1.BorderColor = Color.Red;
                
            }
            if (pass == "")
            {
                var frame1 = loginpassframe;
                frame1.BorderColor = Color.Red; 
            }
            if(pass=="" || mail == "")
            {
                DisplayAlert("Error", "Missing Fields", "OK");
            }
            else
            {

                int i;
                Acc temp = new Acc("","","",false);
                for (i = 0; i < accounts.Count ; i++)
                {
                   if(accounts[i].email == x.email)
                    {
                        temp = accounts[i];
                        break;
                    }
                }



                if (temp.email == x.email && temp.password == x.pass)
                {
                    if (temp.isVerified == false)
                        DisplayAlert("Error", "Email not Verifed. Sent another verification email", "OK");
                    else
                    {
                       
                        Application.Current.Properties["email"] = mail;
                        Application.Current.Properties["name"] = temp.Name;
                        Application.Current.SavePropertiesAsync();
                        Application.Current.MainPage = new Tabs();
                    }
                }
                else
                {
                    DisplayAlert("Error", "Incorrect Email/Password!", "OK");
                }
                
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
        private void passFocusedevent(object sender, FocusEventArgs e)
        {
            var frame1 = loginpassframe;
            if (frame1.BorderColor == Color.Red)
            {
                frame1.BorderColor = Color.Black;
            }

        }
        void ForgotPassTapped(object sender, EventArgs args)
        {
            
            Navigation.PushAsync(new ForgotPassword());
        }
        void RegisterClicked(object sender, EventArgs args)
        {

            Navigation.PushAsync(new Register());
        }
    }
    public class DataEntries : INotifyPropertyChanged
    {
        string _email { get; set; } = "";
        string _pass { get; set; } = "";


        public string email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(email)); }
        }
        public string pass
        {
            get { return _pass; }
            set { _pass = value; OnPropertyChanged(nameof(pass)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
