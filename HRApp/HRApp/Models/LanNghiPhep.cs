using System;
using System.Collections.Generic;
using System.Text;

namespace HRApp.Models
{
    public class LanNghiPhep : BaseModel
    {
        public int NhanVien { get; set; }
        public DateTime? NgayTaoDonXin { get; set; }
        public DateTime? NgayNghi { get; set; }
        public double? SoNgayNghi { get; set; }
        public string LyDo { get; set; }
    }
}
