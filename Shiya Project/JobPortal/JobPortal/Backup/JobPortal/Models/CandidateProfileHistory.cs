using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class CandidateProfileHistory
    {
        public decimal EMCP_Id { get; set; }
        public decimal Cand_Id { get; set; }
        public Nullable<decimal> Job_Id { get; set; }
        public string ProfileHistory { get; set; }
        public Nullable<System.DateTime> ViewedDateTime { get; set; }
        public Nullable<bool> IsShortlisted { get; set; }
    }
}