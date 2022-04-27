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
    public partial class ConversationPage : ContentPage
    {
        public ObservableCollection<MessageModel> Messages = new ObservableCollection<MessageModel>();
        public Conversation P = new Conversation(); 
        public ConversationPage( string Namer)
        {
            InitializeComponent();

            BindingContext = P;

            P.name = Namer;       

            

            MyListView.ItemsSource = Messages;
            if(Messages.Count!=0)
                MyListView.ScrollTo(Messages[Messages.Count - 1], ScrollToPosition.End, true);
        }
    
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (Blankmsg.IsVisible == true)
            {
                Blankmsg.IsVisible = false;
            }
            Messages.Add(new MessageModel()
            {
                _body = P.editor,
                _sender = "SEND"
            }); 
            Messages.Add(new MessageModel()
            {
                _body = "response sample",
                _sender = ""
            });
            MyListView.ScrollTo(Messages[Messages.Count - 1], ScrollToPosition.End, true);
            P.editor = "";

        }
        private void Back_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        private void editorbox_Focused(object sender, FocusEventArgs e)
        {
            editorbox.HeightRequest *= 1.5;
            editorframe.HeightRequest *= 1.5;
            editorframe.Padding = new Thickness(10, 10, 0, 20);

        }

        private void editorbox_Unfocused(object sender, FocusEventArgs e)
        {
            editorbox.HeightRequest /= 1.5;
            editorframe.HeightRequest /= 1.5;
            editorframe.Padding = new Thickness(10, 10, 0, 0);
        }
    }
    public class Conversation : INotifyPropertyChanged
    {
        public string _editor { get; set; } = "";
        public string _name { get; set; } = "";
        public string editor
        {
            get { return _editor; }
            set { _editor = value; OnPropertyChanged(nameof(editor)); }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(name)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
