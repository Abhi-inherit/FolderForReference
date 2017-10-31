using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JobPortal.Models.Mapping
{
    public class vw_ViewProfileHistoryMap : EntityTypeConfiguration<vw_ViewProfileHistory>
    {
        public vw_ViewProfileHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Cand_Id);

            // Properties
            this.Property(t => t.Emp_Name)
                .HasMaxLength(50);

            this.Property(t => t.Cand_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Job_Title)
                .HasMaxLength(50);

            this.Property(t => t.Job_Designation)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_ViewProfileHistory");
            this.Property(t => t.Emp_Name).HasColumnName("Emp_Name");
            this.Property(t => t.Cand_Id).HasColumnName("Cand_Id");
            this.Property(t => t.Job_Id).HasColumnName("Job_Id");
            this.Property(t => t.ViewedDateTime).HasColumnName("ViewedDateTime");
            this.Property(t => t.IsShortlisted).HasColumnName("IsShortlisted");
            this.Property(t => t.Job_Title).HasColumnName("Job_Title");
            this.Property(t => t.Job_Designation).HasColumnName("Job_Designation");
            this.Property(t => t.Job_Description).HasColumnName("Job_Description");
        }
    }
}
