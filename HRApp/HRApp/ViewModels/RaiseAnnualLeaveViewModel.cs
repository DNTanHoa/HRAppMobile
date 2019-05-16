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
	public class RaiseAnnualLeaveViewModel : ViewModelBase
	{
        ODataService oDataService;
        public RaiseAnnualLeaveViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Trang Quản Lý Giờ Công";
            ConfirmCommand = new DelegateCommand(async () => await ConfirmCommandExecute());
        }
        private string _nguoiXinPhep;
        public string nguoiXinPhep
        {
            get => _nguoiXinPhep;
            set
            {
                SetProperty(ref _nguoiXinPhep, value);
                RaisePropertyChanged("nguoiXinPhep");
            }
        }
        private DateTime _ngayTaoDon = DateTime.Today;
        public DateTime ngayTaoDon
        {
            get => _ngayTaoDon;
            set => SetProperty(ref _ngayTaoDon, value);
        }
        private DateTime _ngayNghi = DateTime.Today.AddDays(1);
        public DateTime ngayNghi
        {
            get => _ngayNghi;
            set
            {
                SetProperty(ref _ngayNghi, value);
                RaisePropertyChanged("ngayNghi");
            }
        }
        private int _soNgay = 1;
        public int soNgay
        {
            get => _soNgay;
            set
            {
                SetProperty(ref _soNgay, value);
                RaisePropertyChanged("soNgay");
            }
        }
        private string _LyDo;
        public string LyDo
        {
            get => _LyDo;
            set
            {
                SetProperty(ref _LyDo, value);
                RaisePropertyChanged("LyDo");
            }
        }
        public DelegateCommand ConfirmCommand { get; }
        public async Task ConfirmCommandExecute()
        {
            if (this.LyDo == null)
            {
                await App.Current.MainPage.DisplayAlert("Xin Nghỉ Phép", "Lý Do Không Được Để Trống", "Xác Nhận");
            }
            else if (this.ngayNghi == null)
            {
                await App.Current.MainPage.DisplayAlert("Xin Nghỉ Phép", "Ngày Nghỉ Không Được Để Trống", "Xác Nhận");
            }
            else
            {
                try
                {
                    LanNghiPhep lanNghiPhep = new LanNghiPhep
                    {
                        NgayTaoDonXin = this.ngayTaoDon,
                        NgayNghi = this.ngayNghi,
                        NhanVien = this.IdNhanVien,
                        LyDo = this.LyDo,
                        SoNgayNghi = this.soNgay,
                    };
                    await oDataService.SaveLeave(lanNghiPhep);
                    await App.Current.MainPage.DisplayAlert("Xin Nghỉ Phép", "Đã Lưu Thông Tin Chờ Xác Nhận", "Xác Nhận");
                    await NavigationService.GoBackAsync();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }
        private string _maNhanVien;
        public string maNhanVien
        {
            get => _maNhanVien;
            set => SetProperty(ref _maNhanVien, value);
        }
        private int _IdNhanVien;
        public int IdNhanVien
        {
            get => _IdNhanVien;
            set => SetProperty(ref _IdNhanVien, value);
        }
        private NhanVien _nhanVien;
        public NhanVien nhanVien
        {
            get => _nhanVien;
            set
            {
                SetProperty(ref _nhanVien, value);
                RaisePropertyChanged("nhanVien");
            }
        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            this.oDataService = parameters.GetValue<ODataService>("service");
            NhanVien nv = parameters.GetValue<NhanVien>("nhanVien");
            this.maNhanVien = nv.userName;
            this.IdNhanVien = nv.Id;
            try
            {
                NhanVien nhanVien = await oDataService.GetEmployee(this.maNhanVien);
                this.nguoiXinPhep = nhanVien.Name;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
