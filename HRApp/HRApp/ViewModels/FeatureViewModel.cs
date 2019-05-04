using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRApp.ViewModels
{
	public class FeatureViewModel : ViewModelBase
	{
        public FeatureViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Trang Tính Năng";
        }
    }
}
