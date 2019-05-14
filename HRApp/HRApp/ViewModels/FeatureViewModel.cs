using HRApp.Models;
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
        private NhanVien _nhanVien;
        public NhanVien nhanVien
        {
            get => _nhanVien;
            set => SetProperty(ref _nhanVien, value);
        }
        public override  void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                this.nhanVien = parameters.GetValue<NhanVien>("nhanVien");
            }
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
