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
        }

        private async Task RaiseComeLateExecute()
        {
            await NavigationService.NavigateAsync("RaiseComeLate");
        }

        private async Task RasieOverTimeExecute()
        {
            await NavigationService.NavigateAsync("RaiseOvertime");
        }

        private async Task RasieAnnualLeaveExecute()
        {
            await NavigationService.NavigateAsync("RaiseAnnualLeave");
        }

        public DelegateCommand RasieAnnualLeave { get; set; }
        public DelegateCommand RaiseOvertime { get; set; }
        public DelegateCommand RaiseComeLate { get; set; }

    }
}
