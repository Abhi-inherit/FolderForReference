using System;
using System.Collections.Generic;

namespace JobPortal.Models
{
    public partial class tbl_Candidate
    {
        public decimal Cand_Id { get; set; }
        public long Cand_CategoryId { get; set; }
        public long Cand_LocationId { get; set; }
        public long Cand_ExpLevelId { get; set; }
        public string Cand_Name { get; set; }
        public string Cand_UserName { get; set; }
        public string Cand_Password { get; set; }
        public string Cand_EmailId { get; set; }
        public string Cand_MobileNumber { get; set; }
        public string Cand_Address { get; set; }
        public string Cand_HighestQualification { get; set; }
        public string Cand_SkillDescription { get; set; }
        public string Cand_Resume { get; set; }
        public Nullable<System.DateTime> Cand_DateTime { get; set; }
    }
}
