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
    public class MessageModel : INotifyPropertyChanged
    {
        public string _body { get; set; } = "";
        public string _sender { get; set; } = ""; 
        public string body
        {
            get { return _body; }
            set { _body = value; OnPropertyChanged(nameof(body)); }
        }
        public string sender
        {
            get { return _sender; }
            set { _sender = value; OnPropertyChanged(nameof(sender)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

