using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRApp.ViewModels
{
	public class InformationDetailViewModel : ViewModelBase
	{
        public InformationDetailViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Hồ Sơ Cá Nhân";
        }
        string _fullName = "Dương Nguyễn Tấn Hòa";
        public string fullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }
        string _dateOfBirth = "30/11/1997";
        public string dateOfBirth
        {
            get => _dateOfBirth;
            set => SetProperty(ref _dateOfBirth, value);
        }
        string _identificationNumber = "301609905";
        public string identificationNumber
        {
            get => _identificationNumber;
            set => SetProperty(ref _identificationNumber, value);
        }
        string _countryside = "huyện Bến Lức, tỉnh Long An";
        public string countryside
        {
            get => _countryside;
            set => SetProperty(ref _countryside, value);
        }
        string _salary = "8.000.000";
        public string salary
        {
            get => _salary;
            set => SetProperty(ref _salary, value);
        }
        string _phone = "0359759402";
        public string phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }
        string _email = "tanhoatm@gmail.com";
        public string email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        string _position = "Nhân Viên";
        public string position
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }
        string _department = "Phòng RD";
        public string department
        {
            get => _department;
            set => SetProperty(ref _department, value);
        }
        string _departmentCode = "DA";
        public string departmentCode
        {
            get => _departmentCode;
            set => SetProperty(ref _departmentCode, value);
        }
        string _employeeCode = "DA-04";
        public string employeeCode
        {
            get => _employeeCode;
            set => SetProperty(ref _employeeCode, value);
        }
        string _startDate = "01/03/2019";
        public string startDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }
    }
}
