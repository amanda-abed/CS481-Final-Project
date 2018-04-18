using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace CS481Final.Views
{
    public partial class LogPage : ContentPage
    {
        public LogPage()
        {
            InitializeComponent();
        }

        void Handle_DateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(Handle_DateSelected)}");
        }
    }
}
