using System;
using System.Collections.Generic;
using System.Text;

namespace HRApp.Models
{
    public class NgayLe : BaseModel
    {
        public string TenNgayLe { get; set; }
        public DateTime NgayBatDau { get; set; }
        public int? SoNgayNghi { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string GhiChu { get; set; }
    }
}
