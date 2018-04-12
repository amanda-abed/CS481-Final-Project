using System.Diagnostics;
using Prism.Mvvm;

namespace CS481Final.ViewModels
{
    public class CS481FinalPageViewModel : BindableBase
    {
        public CS481FinalPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}: ctor");
        }
    }
}