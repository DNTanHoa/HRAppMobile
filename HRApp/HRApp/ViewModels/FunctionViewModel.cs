using HRApp.Models;
using HRApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ViewModels
{
	public class FunctionViewModel : ViewModelBase
	{
        public FunctionViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Trang Chức Năng";
            RasieAnnualLeave = new DelegateCommand(async () => await RasieAnnualLeaveExecute());
            RaiseOvertime = new DelegateCommand(async () => await RasieOverTimeExecute());
            RaiseComeLate = new DelegateCommand(async () => await RaiseComeLateExecute());
            RaiseAddTimeWorking = new DelegateCommand(async () => await RaiseAddTimeWorkingExecute());
        }

        private async Task RaiseAddTimeWorkingExecute()
        {
            NavigationParameters param = new NavigationParameters
            {
                {"nhanVien", this.nhanVien},
                {"service", this.oDataService}
            };
            await NavigationService.NavigateAsync("RaiseAddTimeWorking",param);
        }

        private async Task RaiseComeLateExecute()
        {
            NavigationParameters param = new NavigationParameters
            {
                {"nhanVien", this.nhanVien},
                {"service", this.oDataService}
            };
            await NavigationService.NavigateAsync("RaiseComeLate",param);
        }

        private async Task RasieOverTimeExecute()
        {
            NavigationParameters param = new NavigationParameters
            {
                {"nhanVien", this.nhanVien},
                {"service", this.oDataService}
            };
            await NavigationService.NavigateAsync("RaiseOvertime",param);
        }

        private async Task RasieAnnualLeaveExecute()
        {
            NavigationParameters param = new NavigationParameters
            {
                {"nhanVien", this.nhanVien},
                {"service", this.oDataService}
            };
            await NavigationService.NavigateAsync("RaiseAnnualLeave",param);
        }
        public DelegateCommand RasieAnnualLeave { get; set; }
        public DelegateCommand RaiseOvertime { get; set; }
        public DelegateCommand RaiseComeLate { get; set; }
        public DelegateCommand RaiseAddTimeWorking { get; set; }
        private NhanVien _nhanVien;
        public NhanVien nhanVien
        {
            get => _nhanVien;
            set => SetProperty(ref _nhanVien, value);
        }
        ODataService oDataService;
        public override void OnNavigatingTo(INavigationParameters parameters)
        {
           if(parameters.GetNavigationMode() == NavigationMode.New)
           {
                this.nhanVien = parameters.GetValue<NhanVien>("nhanVien");
                this.oDataService = parameters.GetValue<ODataService>("service");
           }
        }
    }
}
