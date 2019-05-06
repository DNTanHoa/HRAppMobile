using HRApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HRApp.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
        public HomeViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Trang Thông Tin Cá Nhân";
            ViewInformationDetail = new DelegateCommand(async () => await ViewInformationDetailExecute());
        }

        private async Task ViewInformationDetailExecute()
        {
            await NavigationService.NavigateAsync("InformationDetail");
        }

        private string _FullName = "Võ Đình Tri";
        public string FullName
        {
            get => _FullName;
            set => SetProperty (ref _FullName, value);
        }
        private string _EmployeeCode = "DA-07";
        public string EmployeeCode
        {
            get => _EmployeeCode;
            set => SetProperty (ref _EmployeeCode, value);
        }
        private string _Department = "Phòng RD";
        public string Department
        {
            get => _Department;
            set => SetProperty (ref _Department, value);
        }
        private string _Supervisor = "Trương Quang Vinh";
        public string Supervisor
        {
            get => _Supervisor;
            set => SetProperty (ref _Supervisor, value);
        }
        public DelegateCommand ViewInformationDetail { get; set;}
    }
}
