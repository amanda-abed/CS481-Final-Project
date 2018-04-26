using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Plugin.LocalNotifications;
using System.Threading.Tasks;
using CS481Final.Services;
using CS481Final.Models;

namespace CS481Final.ViewModels
{
    public class LogPageViewModel : BindableBase, INavigationAware
    {
        IRepository _repository;

        public DelegateCommand SetDate { get; set; }
        public DelegateCommand PullToRefreshCommand { get; set; }
    
        private bool _showIsBusySpinner;
        public bool ShowIsBusySpinner
        {
            get { return _showIsBusySpinner; }
            set { SetProperty(ref _showIsBusySpinner, value); }
        }

        private DateTime _dateSelected;
        public DateTime DateSelectedCommand
        {
            get
            {
                if (_dateSelected == DateTime.MinValue)
                {
                    return DateTime.Now.Date;
                }
                else { return _dateSelected; }
            }
            set { SetProperty(ref _dateSelected, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<IndividualItem> _item;
        public ObservableCollection<IndividualItem> Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public LogPageViewModel(IRepository repository)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(LogPageViewModel)}:  ctor");

            Title = "Logs";

            _repository = repository;

            SetDate = new DelegateCommand(OnSetDate);
            PullToRefreshCommand = new DelegateCommand(OnPullToRefresh);
            RefreshItemList();
        }

        private async void OnPullToRefresh()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnPullToRefresh)}");

            await RefreshItemList();
        }

        private async Task RefreshItemList()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RefreshItemList)}");

            if (Item == null)
            {
                ShowIsBusySpinner = true;
                Item = new ObservableCollection<IndividualItem>();
                ShowIsBusySpinner = false;
            }
            else
            {
                
                ShowIsBusySpinner = true;
                var listOfItems = await _repository.GetItem();
                if(listOfItems != null)
                {
                    Item = new ObservableCollection<IndividualItem>(listOfItems);
                }
                ShowIsBusySpinner = false;
            }
        }

        private void OnSetDate()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnSetDate)}");

            CrossLocalNotifications.Current.Show("Reminder", $"Due date: {DateSelectedCommand.Date}");
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

           if (parameters != null && parameters.ContainsKey("Charged"))
            {
                if(Item == null)
                {
                    Item = new ObservableCollection<IndividualItem>();
                }
                var itemToAdd = (IndividualItem)parameters["Charged"];
                Item.Add(itemToAdd);
                }
        }
    }
}