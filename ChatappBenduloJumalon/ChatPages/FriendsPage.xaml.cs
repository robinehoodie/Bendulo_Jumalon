using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ChatappBenduloJumalon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendsPage : ContentPage
    {
       public ObservableCollection<Friends> Items = new ObservableCollection<Friends>();
        SearchText S = new SearchText();


        public FriendsPage()
        {
            InitializeComponent();

            BindingContext = S;


            MyListView.ItemsSource = Items;

            Items.Add(new Friends()
            {
                Name = "Thomas",
                email = "hlelo"
            });
            Items.Add(new Friends()
            {
                Name = "Robery",
                email = "Apple@gmail.com"
            });
        }

        

       

        private void ImageCell_Tapped(object sender, EventArgs e)
        {
            StackLayout Namer = sender as StackLayout;

            Navigation.PushModalAsync(new ConversationPage(Namer.ClassId));

        }

        private void Searcher_SearchButtonPressed(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SearchPage(S.search));
        }

        public class SearchText : INotifyPropertyChanged
        {
            public string _search { get; set; } = "";
         


            public string search
            {
                get { return _search; }
                set { _search = value; OnPropertyChanged(nameof(search)); }
            }
         

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
