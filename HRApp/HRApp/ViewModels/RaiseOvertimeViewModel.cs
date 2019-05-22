using HRApp.Models;
using HRApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ViewModels
{
	public class RaiseOvertimeViewModel : ViewModelBase
	{
        public RaiseOvertimeViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Trang Tính Năng";
            ConfirmComand = new DelegateCommand(async () => await ConfirmComandExcute());
        }
        ODataService oDataService;
        private string _tenNhanVien;
        public string tenNhanVien
        {
            get => _tenNhanVien;
            set
            {
                SetProperty(ref _tenNhanVien, value);
                RaisePropertyChanged("tenNhanVien");
            }
        }
        private DateTime _ngayTao = DateTime.Today;
        public DateTime ngayTao
        {
            get => _ngayTao;
            set => SetProperty(ref _ngayTao, value);
        }
        private DateTime _ngayTangCa = DateTime.Today;
        public DateTime ngayTangCa
        {
            get => _ngayTangCa;
            set
            {
                SetProperty(ref _ngayTangCa, value);
                RaisePropertyChanged("ngayTangCa");
            }
        }
        private TimeSpan _startTime;
        public TimeSpan startTime
        {
            get => _startTime;
            set
            {
                SetProperty(ref _startTime, value);
                RaisePropertyChanged(nameof(startTime));
                Console.WriteLine("Thời Gian Bắt Đầu Là {0}", startTime);
            }
        }
        private TimeSpan _endTime;
        public TimeSpan endTime
        {
            get => _endTime;
            set
            {
                SetProperty(ref _endTime, value);
                RaisePropertyChanged(nameof(endTime));
                Console.WriteLine("Thời Gian Kết Thúc Là {0}", endTime);
            }
        }
        private string _lyDo;
        public string lyDo
        {
            get => _lyDo;
            set
            {
                SetProperty(ref _lyDo, value);
                RaisePropertyChanged("lyDo");
            }
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
        public DelegateCommand ConfirmComand { get; }
        public async Task ConfirmComandExcute()
        {
            if(this.lyDo == null)
            {
                await App.Current.MainPage.DisplayAlert("Tăng Ca", "Lý do không được để trống", "Xác Nhận");
            }
            else
            {
                try
                {
                    LanTangCa lanTangCa = new LanTangCa
                    {
                        NhanVien = this.nhanVien.Id,
                        NgayTangCa = this.ngayTangCa,
                        NgayTao = this.ngayTao,
                        ThoiGianBatDau = this.ngayTangCa + this.startTime,
                        ThoiGianKetThuc = this.ngayTangCa + this.endTime,
                        LyDo = this.lyDo
                    };
                    await oDataService.SaveOverTime(lanTangCa);
                    await App.Current.MainPage.DisplayAlert("Tăng Ca", "Đã lưu thông tin vui lòng chờ duyệt", "Xác Nhận");
                    await NavigationService.GoBackAsync();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            this.nhanVien = parameters.GetValue<NhanVien>("nhanVien");
            this.oDataService = parameters.GetValue<ODataService>("service");
            try
            {
                this.nhanVien = await oDataService.GetEmployee(this.nhanVien.userName);
                this.tenNhanVien = this.nhanVien.Name;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}
