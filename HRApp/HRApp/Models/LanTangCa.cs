using System;
using System.Collections.Generic;
using System.Text;

namespace HRApp.Models
{
    public class LanTangCa : BaseModel
    {
        public int NhanVien { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayTangCa {get; set;}
        public int LoaiTangCa { get; set; }
        public double HesoNhanGio { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string LyDo { get; set; }
    }
}
