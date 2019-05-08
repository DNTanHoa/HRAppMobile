using HRApp.Models;
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
        public WarrantViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "Trang Quản Lý Phép";
        }
        IEnumerable<AnnualLeave> _annualLeaves;
        public IEnumerable<AnnualLeave> annualLeaves
        {
            get => _annualLeaves;
            set => SetProperty(ref _annualLeaves, value);

        }
        private string _quantityOfAnnualLeaves;
        public string quantityOfAnnualLeaves
        {
            get => _quantityOfAnnualLeaves;
            set => SetProperty(ref _quantityOfAnnualLeaves, value);
        }
        private string _quantityOfAnnualLeavesIsNotAllowed;
        public string quantityOfAnnualLeavesIsNotAllowed
        {
            get => _quantityOfAnnualLeavesIsNotAllowed;
            set => SetProperty(ref _quantityOfAnnualLeavesIsNotAllowed, value);
        }
        private string _lastestDateCreatedOfAnnualLeave;
        public string lastestDateCreatedOfAnnualLeave
        {
            get => _lastestDateCreatedOfAnnualLeave;
            set => SetProperty(ref _lastestDateCreatedOfAnnualLeave, value);
        }
        IEnumerable<ComeLate> _comeLates;
        public IEnumerable<ComeLate> comeLates
        {
            get => _comeLates;
            set => SetProperty(ref _comeLates, value);
        }
        private string _quantityOfComeLate;
        public string quantityOfComeLate
        {
            get => _quantityOfComeLate;
            set => SetProperty(ref _quantityOfComeLate, value);
        }
        private string _quantityOfComeLateIsNotAllowed;
        public string quantityOfComeLateIsNotAllowed
        {
            get => _quantityOfComeLateIsNotAllowed;
            set => SetProperty(ref _quantityOfComeLateIsNotAllowed, value);
        }
        private string _lastestDateCreatedOfComeLate;
        public string lastestDateCreatedOfComeLate
        {
            get => _lastestDateCreatedOfComeLate;
            set => SetProperty(ref _lastestDateCreatedOfComeLate, value);
        }
        IEnumerable<Overtime> _overtimesWorking;
        public IEnumerable<Overtime> OvertimesWorking
        {
            get => _overtimesWorking;
            set => SetProperty(ref _overtimesWorking, value);
        }
        public string _quantityOfOvertimeWorking;
        public string quantityOfOvertimeWorking
        {
            get => _quantityOfOvertimeWorking;
            set => SetProperty(ref _quantityOfOvertimeWorking, value);
        }
        public string _quantityOfOvertimeWorkingIsNotAllowed;
        public string quantityOfOvertimeWorkingIsNotAllowed
        {
            get => _quantityOfOvertimeWorkingIsNotAllowed;
            set => SetProperty(ref _quantityOfOvertimeWorkingIsNotAllowed, value);
        }
        private string _lastestDateCreatedOfTimeWorking;
        public string lastestDateCreatedOfTimeWorking
        {
            get => _lastestDateCreatedOfTimeWorking;
            set => SetProperty(ref _lastestDateCreatedOfTimeWorking, value);
        }
        IEnumerable<AddTime> _addtimes;
        public IEnumerable<AddTime> addtimes
        {
            get => _addtimes;
            set => SetProperty(ref _addtimes, value);
        }
        public string _quantityOfAddtime;
        public string quantityOfAddtime
        {
            get => _quantityOfAddtime;
            set => SetProperty(ref _quantityOfAddtime, value);
        }
        public string _quantityOfAddtimeIsNotAllowed;
        public string quantityOfAddtimeIsNotAllowed
        {
            get => _quantityOfAddtimeIsNotAllowed;
            set => SetProperty(ref _quantityOfAddtimeIsNotAllowed, value);
        }
        private string _lastestDateCreatedOfAddtime;
        public string lastestDateCreatedOfAddtime
        {
            get => _lastestDateCreatedOfAddtime;
            set => SetProperty(ref _lastestDateCreatedOfAddtime, value);
        }
    }
}
