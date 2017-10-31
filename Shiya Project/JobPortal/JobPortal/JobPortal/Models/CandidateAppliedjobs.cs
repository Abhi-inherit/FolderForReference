using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class CandidateAppliedjobs
    {
        public int Cand_id { get; set; }
        public int Job_Id  { get; set; }
        public string Job_Title { get; set; }
        public Nullable<System.DateTime> Job_DateTime { get; set; }
        public string Cand_Name { get; set; }
        public string Cand_HighestQualification { get; set; }
        public string Cand_LocationName { get; set; }
        public Nullable<System.DateTime> Cand_JobAppliedDateTime { get; set; }
    }
}