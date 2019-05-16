using HRApp.Constant;
using HRApp.Models;
using HRApp.Services;
using HRApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HRApp.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
        ODataService _dataService = new ODataService();
        public LoginViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Trang Đăng Nhập";
            loginCommand = new DelegateCommand(OnLoginCommand);
        }
        public DelegateCommand loginCommand { get; }
        public void OnLoginCommand()
        {
            if (this.searchUser())
            {
                NavigationParameters parameters = new NavigationParameters
                {
                    {"nhanVien",this.selectedNhanvien},
                    {"service",this._dataService}
                };
                NavigationService.NavigateAsync("Feature", parameters);
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Đăng Nhập", "Tên Đăng Nhập Hoặc Mật Khẩu Không Chính Xác", "Xác Nhận");
            }
        }
        private NhanVien _selectedNhanVien;
        public NhanVien selectedNhanvien
        {
            get => _selectedNhanVien;
            set => SetProperty(ref _selectedNhanVien, value);
        }
        private bool searchUser()
        {
            bool result = false;
            if(this.employees != null)
            {
                foreach (NhanVien user in this.employees)
                {
                    if ((this.Username == user.userName) && (this.Password == user.passWord))
                    {
                        this.selectedNhanvien = user;
                        result = true;
                        break;
                    }
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Đăng Nhập", "Mạng Lỗi Kiểm Tra Lại Kết Nối Wifi","Xác Nhận");
            }
            return result;
        }
        public async void getSelectedNhanVien()
        {
            try
            {
                await _dataService.GetEmployee(this.Username);
            }
            catch
            {

            }
        }
        private List<NhanVien> _employees;
        public List<NhanVien> employees
        {
            get => _employees;
            set
            {
                SetProperty(ref _employees, value);
                RaisePropertyChanged(nameof(employees));
            }
        }
        private string _userName = "";
        public string Username
        {
            get => _userName;
            set
            {
                SetProperty(ref _userName, value);
                RaisePropertyChanged(nameof(Username));
            }
        }
        private string _passWord = "";
        public string Password
        {
            get => _passWord;
            set
            {
                SetProperty(ref _passWord, value);
                RaisePropertyChanged(nameof(Password));
            }
        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            try
            {
                await _dataService.Login(ServerConfig.serverAddress, ServerConfig.userName, ServerConfig.passWord);
                if (this.employees == null)
                {
                    this.employees = new List<NhanVien>(await _dataService.GetAllEmployee());
                }
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}
