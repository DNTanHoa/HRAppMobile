using System;
using System.Collections.Generic;
using System.Text;

namespace HRApp.Models
{
    public class AnnualLeave
    {
        public int Id { get; set; }
        public NhanVien employee { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLeave { get; set; }
        public bool IsAllowed { get; set; }
    }
}
