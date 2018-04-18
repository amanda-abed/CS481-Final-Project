﻿using System;
using Prism.Mvvm;

namespace CS481Final.ViewModels
{
    public class IndividualItem : BindableBase
    {
        private string _total;
        public string Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }

        public override string ToString()
        {
            return $"Total={Total}";
        }
    }
}