using System;
using System.Collections.Generic;
using System.Text;

namespace HRApp.Models
{
    public enum LoaiPhieu { ditre = 0, vesom = 1, nghiGiuaGio = 2}
    public class LanXinDiTre : BaseModel
    {
        public int Nhanvien { get; set; }
        public LoaiPhieu loaiPhieu { get; set; }
        public DateTime NgayXin { get; set; }
        public string LyDo { get; set; }
    }
}
