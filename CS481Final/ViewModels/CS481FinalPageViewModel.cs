﻿using System;
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
        public DelegateCommand NavToAboutPageCommand { get; set; }
        public DelegateCommand NavToCreatorsPageCommand { get; set; }

        public CS481FinalPageViewModel(INavigationService navigationService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}: ctor");

            nav_service = navigationService;

            NavToLogPageCommand = new DelegateCommand(OnNavToLogPage);
            NavToAddItemPageCommand = new DelegateCommand(OnNavToAddItemPage);

            NavToAboutPageCommand = new DelegateCommand(OnNavToAboutPage);
            NavToCreatorsPageCommand = new DelegateCommand(OnNavToCreatorsPage);
        }

        private async void OnNavToAddItemPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavToAddItemPage)}");

            await nav_service.NavigateAsync("AddItemPage", null);
        }

        private async void OnNavToLogPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavToLogPage)}");

            await nav_service.NavigateAsync("LogPage", null);
        }


        private async void OnNavToAboutPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavToAboutPage)}");

            await nav_service.NavigateAsync("AboutPage", null);
        }

        private async void OnNavToCreatorsPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavToCreatorsPage)}");

            await nav_service.NavigateAsync("CreatorsPage", null);
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