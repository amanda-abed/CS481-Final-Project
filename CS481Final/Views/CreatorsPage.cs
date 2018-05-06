using System;

using Xamarin.Forms;

namespace CS481Final.Views
{
    public class CreatorsPage : ContentPage
    {
        public CreatorsPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

