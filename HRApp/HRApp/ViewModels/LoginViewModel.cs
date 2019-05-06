using HRApp.Models;
using HRApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HRApp.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
        IPageDialogService _dialogService;
        public LoginViewModel(INavigationService navigationService, IPageDialogService dialogService)
           : base(navigationService)
        {
            Title = "Trang Đăng Nhập";
            _dialogService = dialogService;
            loginCommand = new DelegateCommand(OnLoginCommand);
        }
        public DelegateCommand loginCommand { get; }
        public void OnLoginCommand()
        {
            if(this.user.CheckInput())
            {
                Application.Current.MainPage.DisplayAlert("Đăng Nhập", "Đăng Nhập Thành Công", "Xác Nhận");
                //-----------------------------------------------------------------------------------------------
                //
                // Write function to check user in database
                //
                //-----------------------------------------------------------------------------------------------
                NavigationService.NavigateAsync("Feature");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Đăng Nhập", "Đăng Nhập Thất Bại. Tên Đăng Nhập Hoặc Mật Khẩu Không Thể Để Trống", "Xác Nhận");
            }
        }
        public User user
        {
            get
            {
                User user = new User(this.Username, this.Password);
                return user;
            }
        }
        private string _userName = "";
        public string Username
        {
            get => _userName;
            set
            {
                SetProperty(ref _userName, value);
                RaisePropertyChanged(nameof(user));
            }
        }
        private string _passWord = "";
        public string Password
        {
            get => _passWord;
            set
            {
                SetProperty(ref _passWord, value);
                RaisePropertyChanged(nameof(user));
            }
        }
    }
}
