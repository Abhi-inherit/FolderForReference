using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JobPortal.Models.Mapping
{
    public class tbl_CandidateMap : EntityTypeConfiguration<tbl_Candidate>
    {
        public tbl_CandidateMap()
        {
            // Primary Key
            this.HasKey(t => t.Cand_Id);

            // Properties
            this.Property(t => t.Cand_Name)
                .HasMaxLength(50);

            this.Property(t => t.Cand_UserName)
                .HasMaxLength(50);

            this.Property(t => t.Cand_Password)
                .HasMaxLength(50);

            this.Property(t => t.Cand_EmailId)
                .HasMaxLength(50);

            this.Property(t => t.Cand_MobileNumber)
                .HasMaxLength(50);

            this.Property(t => t.Cand_Address)
                .HasMaxLength(50);

            this.Property(t => t.Cand_HighestQualification)
                .HasMaxLength(50);

            this.Property(t => t.Cand_Resume)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tbl_Candidate");
            this.Property(t => t.Cand_Id).HasColumnName("Cand_Id");
            this.Property(t => t.Cand_CategoryId).HasColumnName("Cand_CategoryId");
            this.Property(t => t.Cand_LocationId).HasColumnName("Cand_LocationId");
            this.Property(t => t.Cand_ExpLevelId).HasColumnName("Cand_ExpLevelId");
            this.Property(t => t.Cand_Name).HasColumnName("Cand_Name");
            this.Property(t => t.Cand_UserName).HasColumnName("Cand_UserName");
            this.Property(t => t.Cand_Password).HasColumnName("Cand_Password");
            this.Property(t => t.Cand_EmailId).HasColumnName("Cand_EmailId");
            this.Property(t => t.Cand_MobileNumber).HasColumnName("Cand_MobileNumber");
            this.Property(t => t.Cand_Address).HasColumnName("Cand_Address");
            this.Property(t => t.Cand_HighestQualification).HasColumnName("Cand_HighestQualification");
            this.Property(t => t.Cand_SkillDescription).HasColumnName("Cand_SkillDescription");
            this.Property(t => t.Cand_Resume).HasColumnName("Cand_Resume");
            this.Property(t => t.Cand_DateTime).HasColumnName("Cand_DateTime");
        }
    }
}
