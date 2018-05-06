using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using CS481Final.Services;
using CS481Final.Models;

namespace CS481Final.ViewModels
{
    public class AddItemPageViewModel : BindableBase, INavigationAware
    {
        IRepository _repository;
        INavigationService nav_service;
        IPageDialogService _pageDialogService;

        public DelegateCommand AddToLog { get; set; }
        public DelegateCommand GoBackToHomeScreen { get; set; }
        public DelegateCommand CalculateTotal { get; set; }

        private bool _showIsBusySpinner;
        public bool ShowIsBusySpinner
        {
            get { return _showIsBusySpinner; }
            set { SetProperty(ref _showIsBusySpinner, value); }
        }

        private string _amountCharged;
        public string AmountCharged
        {
            get { return _amountCharged; }
            set { SetProperty(ref _amountCharged, value); }
        }

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

        public AddItemPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,IRepository repository)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddItemPageViewModel)}:  ctor");

            Title = "Add Item";

            _pageDialogService = pageDialogService;
            nav_service = navigationService;
            _repository = repository;

            AddToLog = new DelegateCommand(OnAdd);
            GoBackToHomeScreen = new DelegateCommand(OnCancel);
            CalculateTotal = new DelegateCommand(OnCalculateTotal);
        }

        private void OnCalculateTotal()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCalculateTotal)}");

            double totalNum = Convert.ToDouble(total_amount);
            double totalPeople = Convert.ToDouble(num_people);
            if (totalPeople != 0 || totalPeople == ' ')
            {
                double CalcTotal = totalNum / totalPeople;
                AmountCharged = CalcTotal.ToString("F");
            }
            else
                AmountCharged = "Error";
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
                Total = this.AmountCharged
            };

            bool userResponse = await _pageDialogService.DisplayAlertAsync("Attention!", "Are you sure you want to add a new item?", "Yes", "No");
            if (userResponse == false)
                return;
            else
            {
                ShowIsBusySpinner = true;
                await _repository.AddItem(newItem);
                ShowIsBusySpinner = false;

                var navParams = new NavigationParameters();
                navParams.Add("Charged", newItem);

                await Task.Delay(1);
           
                await nav_service.NavigateAsync("LogPage", navParams);
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