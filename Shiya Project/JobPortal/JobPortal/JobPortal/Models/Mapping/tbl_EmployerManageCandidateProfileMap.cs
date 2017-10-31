using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JobPortal.Models.Mapping
{
    public class tbl_EmployerManageCandidateProfileMap : EntityTypeConfiguration<tbl_EmployerManageCandidateProfile>
    {
        public tbl_EmployerManageCandidateProfileMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EMCP_Id, t.Cand_Id });

            // Properties
            this.Property(t => t.EMCP_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Cand_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("tbl_EmployerManageCandidateProfile");
            this.Property(t => t.EMCP_Id).HasColumnName("EMCP_Id");
            this.Property(t => t.Cand_Id).HasColumnName("Cand_Id");
            this.Property(t => t.Job_Id).HasColumnName("Job_Id");
            this.Property(t => t.ViewedDateTime).HasColumnName("ViewedDateTime");
            this.Property(t => t.IsShortlisted).HasColumnName("IsShortlisted");
        }
    }
}
