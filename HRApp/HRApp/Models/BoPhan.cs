using System;
using System.Collections.Generic;
using System.Text;

namespace HRApp.Models
{
    public class BoPhan : BaseModel
    {
        public string maBoPhan { get; set; }
        public string tenBoPhan { get; set; }
        public NhanVien truongBoPhan { get; set; }
    }
}
