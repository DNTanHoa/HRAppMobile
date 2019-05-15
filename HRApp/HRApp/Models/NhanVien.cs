using System;
using System.Collections.Generic;
using System.Text;

namespace HRApp.Models
{
    public class NhanVien : BaseModel
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public string Name { get; set; }
        public string maNhanVien { get; set; }
        public string department { get; set; }
        public string supervisor { get; set; }
        public string image { get; set; }
        public NhanVien() { }
        public NhanVien(NhanVien nhanVien) { }
    }
}
