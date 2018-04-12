using Xamarin.Forms;
using System.Diagnostics;

namespace CS481Final.Views
{
    public partial class CS481FinalPage : ContentPage
    {
        public CS481FinalPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}: ctor");
            InitializeComponent();
        }
    }
}
