using System;
using System.Collections.Generic;

namespace JobPortal.Models
{
    public partial class tbl_Jobs
    {
        public decimal Job_Id { get; set; }
        public Nullable<long> Job_EmployerId { get; set; }
        public long Job_CategoryId { get; set; }
        public long Job_LocationId { get; set; }
        public long Job_ExpLevelId { get; set; }
        public string Job_Title { get; set; }
        public string Job_Designation { get; set; }
        public string Job_Description { get; set; }
        public Nullable<System.DateTime> Job_DateTime { get; set; }
        public Nullable<bool> Job_Status { get; set; }
    }
}
