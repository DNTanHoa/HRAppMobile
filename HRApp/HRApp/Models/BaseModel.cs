using System;
using System.Collections.Generic;
using System.Text;

namespace HRApp.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public int OptimisticLockFieldInDataLayer { get; set; }
    }
}
