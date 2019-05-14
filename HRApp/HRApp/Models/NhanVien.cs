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
        public NhanVien() { }
        public NhanVien(NhanVien nhanVien) { }
        public NhanVien(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }
        public bool CheckInput()
        {
            if(this.userName.Equals("") || this.passWord.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
