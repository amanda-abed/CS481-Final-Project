﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace CS481Final.ViewModels
{
    public class LogPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand<IndividualItem> ItemSelectedCommand { get; set; }

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

        private IndividualItem selected_item;
        public IndividualItem SelectedItem
        {
            get { return selected_item; }
            set { SetProperty(ref selected_item, value); }
        }

        public LogPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(LogPageViewModel)}:  ctor");

            Title = "Logs";

            ItemSelectedCommand = new DelegateCommand<IndividualItem>(OnItemSelected); 
        }

      /*  void Handle_DateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(Handle_DateSelected)}");
        }*/

        private void OnItemSelected(IndividualItem obj)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnItemSelected)}:  {obj}");
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