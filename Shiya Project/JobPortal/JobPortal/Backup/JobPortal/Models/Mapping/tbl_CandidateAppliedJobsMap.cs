using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JobPortal.Models.Mapping
{
    public class tbl_CandidateAppliedJobsMap : EntityTypeConfiguration<tbl_CandidateAppliedJobs>
    {
        public tbl_CandidateAppliedJobsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Cand_Id, t.Job_Id });

            // Properties
            this.Property(t => t.Cand_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Job_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("tbl_CandidateAppliedJobs");
            this.Property(t => t.Cand_Id).HasColumnName("Cand_Id");
            this.Property(t => t.Job_Id).HasColumnName("Job_Id");
            this.Property(t => t.JobAppliedDateTime).HasColumnName("JobAppliedDateTime");
        }
    }
}
