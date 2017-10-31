using System;
using System.Collections.Generic;

namespace JobPortal.Models
{
    public partial class vw_ViewProfileHistory
    {
        public string Emp_Name { get; set; }
        public decimal Cand_Id { get; set; }
        public Nullable<decimal> Job_Id { get; set; }
        public Nullable<System.DateTime> ViewedDateTime { get; set; }
        public Nullable<bool> IsShortlisted { get; set; }
        public string Job_Title { get; set; }
        public string Job_Designation { get; set; }
        public string Job_Description { get; set; }
    }
}
