using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace CS481Final.ViewModels
{
    public class CS481FinalPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;

        public DelegateCommand NavToLogPageCommand { get; set; }
        public DelegateCommand NavToAddItemPageCommand { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public CS481FinalPageViewModel(INavigationService navigationService)
        {
            Title = "Manage";
            Debug.WriteLine($"**** {this.GetType().Name}: ctor");
            nav_service = navigationService;
            NavToLogPageCommand = new DelegateCommand(OnNavToLogPage);
            NavToAddItemPageCommand = new DelegateCommand(OnNavToAddItemPage);
        }

        private void OnNavToAddItemPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavToAddItemPage)}");

            nav_service.NavigateAsync("AddItemPage");
        }

        private void OnNavToLogPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavToLogPage)}");

            nav_service.NavigateAsync("LogPage");
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