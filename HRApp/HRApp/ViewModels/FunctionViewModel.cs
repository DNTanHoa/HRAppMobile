using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRApp.ViewModels
{
	public class FunctionViewModel : ViewModelBase
	{
        public FunctionViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Trang Chức Năng";
        }
    }
}
