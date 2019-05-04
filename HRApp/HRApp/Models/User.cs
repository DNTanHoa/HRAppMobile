using System;
using System.Collections.Generic;
using System.Text;

namespace HRApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public User() { }
        public User(string userName, string passWord)
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
