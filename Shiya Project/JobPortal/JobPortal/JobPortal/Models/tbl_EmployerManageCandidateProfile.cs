using System;
using System.Collections.Generic;

namespace JobPortal.Models
{
    public partial class tbl_EmployerManageCandidateProfile
    {
        public decimal EMCP_Id { get; set; }
        public decimal Cand_Id { get; set; }
        public Nullable<decimal> Job_Id { get; set; }
        public Nullable<System.DateTime> ViewedDateTime { get; set; }
        public Nullable<bool> IsShortlisted { get; set; }
    }
}
