using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace CS481Final.ViewModels
{
    public class LogPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public LogPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(LogPageViewModel)}:  ctor");
            Title = "Logs";
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }
    }
}