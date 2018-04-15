using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace CS481Final.ViewModels
{
    public class AddItemPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService _pageDialogService;

        public DelegateCommand AddToLog { get; set; }
        public DelegateCommand GoBackToHomeScreen { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string total_amount;
        public string TotalAmount
        {
            get { return total_amount; }
            set { SetProperty(ref total_amount, value); }
        }

        private string num_people;
        public string NumberOfPeople
        {
            get { return num_people; }
            set { SetProperty(ref num_people, value); }
        }

        public AddItemPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddItemPageViewModel)}:  ctor");

            Title = "Add Item";

            _pageDialogService = pageDialogService;
            nav_service = navigationService;
            AddToLog = new DelegateCommand(OnAdd);
            GoBackToHomeScreen = new DelegateCommand(OnCancel);
        }

        private async void OnCancel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCancel)}");

            await nav_service.GoBackAsync();
        }

        private async void OnAdd()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnAdd)}");

            IndividualItem newItem = new IndividualItem
            {
                //AMOUNT CHARGED GOES HERE
                //Total = this. 
            };


            bool userResponse = await _pageDialogService.DisplayAlertAsync("Attention!", "Are you sure you want to add a new item?", "Yes", "No");
            if (userResponse == false)
                return;
            else
            {
                //PASS AMOUNT CHARGED TO LOGPAGE
                var navParams = new NavigationParameters();

                await Task.Delay(1);

                await nav_service.GoBackAsync(navParams);
            }
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