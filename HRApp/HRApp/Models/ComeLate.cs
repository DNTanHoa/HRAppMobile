using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HRApp.Models
{
    public enum KindOfForm
    {
        ComeLate, EarlyBack, Break
    }
    public class ComeLate
    {
        public int Id { get; set; }
        public User user { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateLate { get; set; }
        public KindOfForm KindOfForm { get; set; }
        public string reason { get; set; }
        public bool IsAllowed { get; set; }
        
    }
}
