using System;
using System.Collections.Generic;

namespace JobPortal.Models
{
    public partial class vw_JobDetails
    {
        public Nullable<long> Job_EmployerId { get; set; }
        public long Job_CategoryId { get; set; }
        public long Job_LocationId { get; set; }
        public decimal Job_Id { get; set; }
        public long Job_ExpLevelId { get; set; }
        public string Job_Title { get; set; }
        public string Job_Designation { get; set; }
        public string Job_Description { get; set; }
        public Nullable<System.DateTime> Job_DateTime { get; set; }
        public Nullable<bool> Job_Status { get; set; }
        public string Emp_Name { get; set; }
        public string Cand_Name { get; set; }
        public long Cand_ExpLevelId { get; set; }
        public long Cand_LocationId { get; set; }
        public long Cand_CategoryId { get; set; }
        public string Cand_Address { get; set; }
        public string Cand_HighestQualification { get; set; }
        public string Cand_SkillDescription { get; set; }
        public string Cand_Resume { get; set; }
        public decimal Cand_Id { get; set; }
    }
}
