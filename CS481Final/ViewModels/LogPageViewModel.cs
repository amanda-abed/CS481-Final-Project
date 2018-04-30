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
using Prism.Services;

namespace CS481Final.ViewModels
{
   
    public class LogPageViewModel : BindableBase, INavigationAware
    {
        IPageDialogService _pageDialogService;
        IRepository _repository;

        public DelegateCommand SetDate { get; set; }
        public DelegateCommand PullToRefreshCommand { get; set; }
        public DelegateCommand<IndividualItem> DeleteCommand { get; set; }
        public DelegateCommand<IndividualItem> ShareCommand { get; set; }
    
        private bool _showIsBusySpinner;
        public bool ShowIsBusySpinner
        {
            get { return _showIsBusySpinner; }
            set { SetProperty(ref _showIsBusySpinner, value); }
        }
        private string total_due;
        public string TotalADue
        {
            get { return total_due; }
            set { SetProperty(ref total_due, value); }
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

        public LogPageViewModel(IRepository repository, IPageDialogService pageDialogService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(LogPageViewModel)}:  ctor");

            Title = "Logs";

            _repository = repository;
            _pageDialogService = pageDialogService;

            SetDate = new DelegateCommand(OnSetDate);
            PullToRefreshCommand = new DelegateCommand(OnPullToRefresh);
            DeleteCommand = new DelegateCommand<IndividualItem>(OnDeleteTapped);
            ShareCommand = new DelegateCommand<IndividualItem>(OnShareTapped);
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

        private void OnDeleteTapped(IndividualItem itemToDelete)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnDeleteTapped)}:  {itemToDelete}");
        }

        private async void OnShareTapped(IndividualItem itemToShare)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnShareTapped)}:  {itemToShare}");

            string response = await _pageDialogService.DisplayActionSheetAsync(null, "Cancel", null, "Text", "Email", "Call");
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnShareTapped)}:  {itemToShare}, {response}");

            if (response.Equals("Text")) {
                Debug.WriteLine("ActionMenu: Text");
            }
            else if (response.Equals("Email")){
                Debug.WriteLine("ActionMenu: Email");
            }
            else if (response.Equals("Call")) {
                Debug.WriteLine("ActionMenu: Call");
            }
            else {
                Debug.WriteLine("ActionMenu: Cancel");
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

        public async void OnNavigatingTo(NavigationParameters parameters)
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

                 TotalADue = itemToAdd.ToString();

            }
        }
       
    }
}