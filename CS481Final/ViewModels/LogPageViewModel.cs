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

        //public DelegateCommand PullToRefreshCommand { get; set; }


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

           // RefreshPeopleList();
        }

        /*
        private async Task RefreshPeopleList()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RefreshPeopleList)}");

            var listOfItems = await _repository.GetItem();
            Item = new ObservableCollection<IndividualItem>(listOfItems);
        }*/

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
                var itemToAdd = (IndividualItem)parameters["Charged"];
                Item.Add(itemToAdd);
            }
        }
    }
}