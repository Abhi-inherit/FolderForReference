using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class 

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

        public string CategoryName { get; set; }
        public string LocationName { get; set; }
        public string Experience { get; set; }
        public string EmployerName { get; set; }
    }
}