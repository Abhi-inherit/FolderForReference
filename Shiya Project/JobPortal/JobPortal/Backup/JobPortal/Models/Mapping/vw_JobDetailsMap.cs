using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JobPortal.Models.Mapping
{
    public class vw_JobDetailsMap : EntityTypeConfiguration<vw_JobDetails>
    {
        public vw_JobDetailsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Job_CategoryId, t.Job_LocationId, t.Job_Id, t.Job_ExpLevelId, t.Cand_ExpLevelId, t.Cand_LocationId, t.Cand_CategoryId, t.Cand_Id });

            // Properties
            this.Property(t => t.Job_CategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Job_LocationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Job_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Job_ExpLevelId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Job_Title)
                .HasMaxLength(50);

            this.Property(t => t.Job_Designation)
                .HasMaxLength(50);

            this.Property(t => t.Emp_Name)
                .HasMaxLength(50);

            this.Property(t => t.Cand_Name)
                .HasMaxLength(50);

            this.Property(t => t.Cand_ExpLevelId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Cand_LocationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Cand_CategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Cand_Address)
                .HasMaxLength(50);

            this.Property(t => t.Cand_HighestQualification)
                .HasMaxLength(50);

            this.Property(t => t.Cand_Resume)
                .HasMaxLength(50);

            this.Property(t => t.Cand_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_JobDetails");
            this.Property(t => t.Job_EmployerId).HasColumnName("Job_EmployerId");
            this.Property(t => t.Job_CategoryId).HasColumnName("Job_CategoryId");
            this.Property(t => t.Job_LocationId).HasColumnName("Job_LocationId");
            this.Property(t => t.Job_Id).HasColumnName("Job_Id");
            this.Property(t => t.Job_ExpLevelId).HasColumnName("Job_ExpLevelId");
            this.Property(t => t.Job_Title).HasColumnName("Job_Title");
            this.Property(t => t.Job_Designation).HasColumnName("Job_Designation");
            this.Property(t => t.Job_Description).HasColumnName("Job_Description");
            this.Property(t => t.Job_DateTime).HasColumnName("Job_DateTime");
            this.Property(t => t.Job_Status).HasColumnName("Job_Status");
            this.Property(t => t.Emp_Name).HasColumnName("Emp_Name");
            this.Property(t => t.Cand_Name).HasColumnName("Cand_Name");
            this.Property(t => t.Cand_ExpLevelId).HasColumnName("Cand_ExpLevelId");
            this.Property(t => t.Cand_LocationId).HasColumnName("Cand_LocationId");
            this.Property(t => t.Cand_CategoryId).HasColumnName("Cand_CategoryId");
            this.Property(t => t.Cand_Address).HasColumnName("Cand_Address");
            this.Property(t => t.Cand_HighestQualification).HasColumnName("Cand_HighestQualification");
            this.Property(t => t.Cand_SkillDescription).HasColumnName("Cand_SkillDescription");
            this.Property(t => t.Cand_Resume).HasColumnName("Cand_Resume");
            this.Property(t => t.Cand_Id).HasColumnName("Cand_Id");
        }
    }
}
