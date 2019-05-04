using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRApp.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
        public HomeViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Trang Thông Tin Cá Nhân";
        }
    }
}
