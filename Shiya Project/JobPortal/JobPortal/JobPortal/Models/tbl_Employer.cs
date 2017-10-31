using System;
using System.Collections.Generic;

namespace JobPortal.Models
{
    public partial class tbl_Employer
    {
        public long Emp_Id { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_Address { get; set; }
        public string Emp_ContactPersonName { get; set; }
        public string Emp_EmailId { get; set; }
        public string Emp_MobileNumber { get; set; }
        public string Emp_Place { get; set; }
        public string Emp_LogoImage { get; set; }
        public Nullable<System.DateTime> Emp_DateTime { get; set; }
        public Nullable<bool> Emp_Status { get; set; }
        public string Emp_UserName { get; set; }
        public string Emp_Password { get; set; }
    }
}
