using System;
using System.Collections.Generic;

namespace JobPortal.Models
{
    public partial class tbl_CandidateAppliedJobs
    {
        public decimal Cand_Id { get; set; }
        public decimal Job_Id { get; set; }
        public Nullable<System.DateTime> JobAppliedDateTime { get; set; }
    }
}
