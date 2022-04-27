using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatappBenduloJumalon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            
            ProfEmail.Text = Convert.ToString(Application.Current.Properties["email"]);
            ProfName.Text =Convert.ToString(Application.Current.Properties["name"]);
        }

        private void SignOut_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.Properties.Remove("email");
            Xamarin.Forms.Application.Current.Properties.Remove("Name");
            Xamarin.Forms.Application.Current.SavePropertiesAsync();
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}