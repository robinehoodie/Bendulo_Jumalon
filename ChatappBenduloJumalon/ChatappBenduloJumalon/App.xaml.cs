using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatappBenduloJumalon
{
    public partial class App : Application
    {
        
        public static float screenWidth { get; set; }
        public static float screenHeight { get; set; }
        public static float appScale{ get; set; }

        
        public App()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("email"))
            {
                Application.Current.MainPage = new Tabs();
            }
                
            else
                MainPage = new NavigationPage( new MainPage());
            
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
    public class Acc
    {
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isVerified { get; set; }

        public Acc(string v1,string v2, string v3, bool v4)
        {
            this.Name = v1;
            this.email = v2;
            this.password = v3;
            this.isVerified = v4;
        }

        
    }
}
