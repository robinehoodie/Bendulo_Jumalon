using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatappBenduloJumalon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public ObservableCollection<Friends> Items = new ObservableCollection<Friends>();
        public ObservableCollection<Friends> FL = new ObservableCollection<Friends>();
        public SearchPage(string contents)
        {
      
            InitializeComponent();


            Items.Add(new Friends()
            {
                Name = "hi",
                email = "hlelo"
            });
            Items.Add(new Friends()
            {
                Name = "hames",
                email = "Bond"
            });
            Items.Add(new Friends()
            {
                Name = "amy",
                email = "patts"
            });

            var first = Items.Where(a => a.email.ToLower().Contains(contents)).ToList();
            var second = Items.Where(a => a.Name.ToLower().Contains(contents)).ToList();
            
            var filteredList = new ObservableCollection<Friends>(first.Union(second));
             
            if (filteredList.Count == 0)
            {
                
               
                DisplayAlert("", "User Not Found", "Okay");
               // Navigation.PushModalAsync(new Tabs());

            }
            
           
            MyListView.ItemsSource = filteredList;
        }
        
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            StackLayout dude = sender as StackLayout;
            string h = dude.ClassId.ToString();
 
            int x = 0;
            string k = "";
            int l= 0;
            for(;x<Items.Count(); x++)
            {
                if (Items[x].email == h)
                {
                    k = Items[x].Name;
                    break;
                }
            }
            
            bool choice = await DisplayAlert("Add Contact", "Would you like to add " + k, "yes", "no");
            if (choice)
            {
                for (x=0; x < FL.Count(); x++)
                {
                    if (FL[x].email == h)
                    {
                        l = 1;
                        break;
                    }
                }
                if (l== 0)
                {
                    FL.Add(new Friends()
                    {
                        Name = k,
                        email = h
                    });
                }
                else
                {
                    await DisplayAlert("Error", "Already Friends", "OK");
                }
                
              

            }
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }
    }
}
