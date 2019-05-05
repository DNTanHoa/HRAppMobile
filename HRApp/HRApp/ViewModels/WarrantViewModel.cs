using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRApp.ViewModels
{
	public class WarrantViewModel : ViewModelBase
	{
        public WarrantViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Trang Quản Lý Phép";
        }
    }
}
