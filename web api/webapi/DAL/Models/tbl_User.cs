using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class tbl_User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string location { get; set; }
        public string gender { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<System.DateTime> lastModified { get; set; }
        public string isActive { get; set; }
    }
}
