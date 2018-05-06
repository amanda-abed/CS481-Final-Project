using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace CS481Final.ViewModels
{

    public class CreatorsPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;

        public CreatorsPageViewModel(INavigationService navigationService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}: ctor");

            nav_service = navigationService;

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