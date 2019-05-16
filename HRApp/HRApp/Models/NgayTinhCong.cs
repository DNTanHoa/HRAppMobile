using System;
using System.Collections.Generic;
using System.Text;

namespace HRApp.Models
{
    public class NgayTinhCong : BaseModel
    {
        public DateTime ngayTinhCong { get; set; }
        public string TenNhanVien { get; set; }
        public int nhanVien { get; set; }
        public int soGioCoBan { get; set; }
        public int soGioTangCa { get; set; }
    }
}
