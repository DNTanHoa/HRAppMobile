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
	public class RaiseComeLateViewModel : ViewModelBase
	{
        public RaiseComeLateViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Phiếu Xin Đi Trễ";
            ConfirmCommand = new DelegateCommand(async () => await ConfirmCommandExcute());
        }
        private IList<string> _source;
        public IList<string> source
        {
            get => _source;
            set
            {
                SetProperty(ref _source, value);
                RaisePropertyChanged(nameof(source));
            }
        }
        private LoaiPhieu _loaiPhieu;
        public LoaiPhieu loaiPhieu
        {
            get => _loaiPhieu;
            set
            {
                SetProperty(ref _loaiPhieu, value);
                RaisePropertyChanged(nameof(loaiPhieu));
            }
        }
        public DelegateCommand ConfirmCommand { get; }
        public async Task ConfirmCommandExcute()
        {
            if(this.LyDo == null)
            {
                await App.Current.MainPage.DisplayAlert("Thông Báo", "Lý Do Không Được Để Trống", "Xác Nhận");
            }
            else
            {
                try
                {
                    LanXinDiTre lanXinDiTre = new LanXinDiTre
                    {
                        Nhanvien = this.IdNhanVien,
                        NgayXin = this.ngayXin,
                        LyDo = this.LyDo,
                        loaiPhieu = LoaiPhieu.ditre
                    };
                    await oDataService.SaveComeLate(lanXinDiTre);
                    await App.Current.MainPage.DisplayAlert("Thông Báo", "Nội Dung Đã Lưu. Chờ Duyệt", "Xác Nhận");
                    await NavigationService.GoBackAsync();
                }
                catch(Exception exception)
                {
                    throw exception;
                }
            }
        }
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
        private NhanVien _nhanVien;
        public NhanVien nhanVien
        {
            get => _nhanVien;
            set
            {
                SetProperty(ref _nhanVien, value);
                RaisePropertyChanged(nameof(nhanVien));
            }
        }
        private int _selectedItem;
        public int selectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem,value);
                RaisePropertyChanged(nameof(selectedItem));
                Console.WriteLine("Loại Phiếu Đươc Chọn Là {}", this.selectedItem);
            }
        }
        private DateTime _ngayTao = DateTime.Today;
        public DateTime ngayTao
        {
            get => _ngayTao;
            set
            {
                SetProperty(ref _ngayTao, value);
                RaisePropertyChanged(nameof(ngayTao));
            }
        }
        private DateTime _ngayXin;
        public DateTime ngayXin
        {
            get => _ngayXin;
            set
            {
                SetProperty(ref _ngayXin, value);
                RaisePropertyChanged(nameof(ngayXin));
            }
        }
        private int _IdNhanVien;
        public int IdNhanVien
        {
            get => _IdNhanVien;
            set => SetProperty(ref _IdNhanVien, value);
        }
        private string _lyDo;
        public string  LyDo
        {
            get => _lyDo;
            set
            {
                SetProperty(ref _lyDo, value);
                RaisePropertyChanged(nameof(LyDo));
            }
        }
        ODataService oDataService;
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            this.nhanVien = parameters.GetValue<NhanVien>("nhanVien");
            this.oDataService = parameters.GetValue<ODataService>("service");
            try
            {
                this.nhanVien = await oDataService.GetEmployee(this.nhanVien.userName);
                this.IdNhanVien = this.nhanVien.Id;
                this.tenNhanVien = this.nhanVien.Name;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
