using System;
using System.Collections.Generic;
using System.Text;

namespace HRApp.Models
{
    public class NgayLe : BaseModel
    {
        public string tenNgayLe { get; set; }
        public DateTime ngayBatDauNghi { get; set; }
        public int? soNgayNghi { get; set; }
        public DateTime? ngayKetThuc { get; set; }
    }
}
