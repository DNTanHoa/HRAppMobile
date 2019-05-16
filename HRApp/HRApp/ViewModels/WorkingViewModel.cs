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
	public class WorkingViewModel : ViewModelBase
	{
        ODataService oDataService;
        public WorkingViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Trang Quản Lý Giờ Công";
            ViewResultCommand = new DelegateCommand(ViewResultCommandExecute);
        }
        DateTime _startDate = new DateTime(DateTime.Today.Year,DateTime.Today.Month,1);
        public DateTime startDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }
        DateTime _endDate = DateTime.Today;
        public DateTime endDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }
        private string _sumOfDate;
        public string sumOfDate
        {
            get => _sumOfDate;
            set => SetProperty(ref _sumOfDate, value);
        }
        private string _dateOffAllow = "0";
        public string dateOffAllow
        {
            get => _dateOffAllow;
            set => SetProperty(ref _dateOffAllow, value);
        }
        private string _dateWorking = "0";
        public string dateWorking
        {
            get => _dateWorking;
            set => SetProperty(ref _dateWorking, value);
        }
        private string _workingHour = "0";
        public string workingHour
        {
            get => _workingHour;
            set => SetProperty(ref _workingHour, value);
        }
        private string _numOfOvertime = "0";
        public string numOfOvertime
        {
            get => _numOfOvertime;
            set => SetProperty(ref _numOfOvertime, value);
        }
        private string _overtimeHour = "0";
        public string overtimeHour
        {
            get => _overtimeHour;
            set => SetProperty(ref _overtimeHour, value);
        }
        private string _numOfComeLate = "0";
        public string numOfComeLate
        {
            get => _numOfComeLate;
            set => SetProperty(ref _numOfComeLate, value);
        }
        private string _numOfAnnualLeave = "0";
        public string numOfAnnualLeave
        {
            get => _numOfAnnualLeave;
            set => SetProperty(ref _numOfAnnualLeave, value);
        }
        public DelegateCommand ViewResultCommand { get; set; }
        public void ViewResultCommandExecute()
        {
            this.sumOfDate = CalculateSumOfDate().ToString();
            this.dateOffAllow = CalculateDateOffAllow().ToString();
            this.dateWorking = Convert.ToString(CalculateSumOfDate() - CalculateDateOffAllow());
        }
        private int CalculateSumOfDate()
        {
            TimeSpan sumOfDate = this.endDate - this.startDate;
            return (int)Math.Abs(sumOfDate.TotalDays);
        }
        private int CalculateDateOffAllow()
        {
            int sum = 0;
            if(this.holidays != null)
            {
                for (DateTime date = this.startDate; date < this.endDate; date = date.AddDays(1))
                {
                    foreach (NgayLe holiday in this.holidays)
                    {
                        if((holiday.NgayBatDau <= date) && (holiday.NgayKetThuc >= date))
                        {
                            sum += 1;
                            goto continueCalculate;
                        }
                    }
                    if (date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        sum += 1;
                    }
                    continueCalculate: continue;
                }
            }
            return sum;
        }
        private List<NgayLe> _holidays;
        public List<NgayLe> holidays
        {
            get => _holidays;
            set => SetProperty(ref _holidays, value);
        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            oDataService = parameters.GetValue<ODataService>("service");
            if(this.holidays == null)
            {
                this.holidays = new List<NgayLe>(await oDataService.GetHolidays());
            }
        }
    }
}
