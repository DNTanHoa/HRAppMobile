using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRApp.ViewModels
{
	public class WorkingViewModel : ViewModelBase
	{
        public WorkingViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Trang Quản Lý Giờ Công";
        }
    }
}
