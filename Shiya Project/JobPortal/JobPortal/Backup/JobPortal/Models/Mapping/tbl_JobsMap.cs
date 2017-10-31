using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JobPortal.Models.Mapping
{
    public class tbl_JobsMap : EntityTypeConfiguration<tbl_Jobs>
    {
        public tbl_JobsMap()
        {
            // Primary Key
            this.HasKey(t => t.Job_Id);

            // Properties
            this.Property(t => t.Job_Title)
                .HasMaxLength(50);

            this.Property(t => t.Job_Designation)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tbl_Jobs");
            this.Property(t => t.Job_Id).HasColumnName("Job_Id");
            this.Property(t => t.Job_EmployerId).HasColumnName("Job_EmployerId");
            this.Property(t => t.Job_CategoryId).HasColumnName("Job_CategoryId");
            this.Property(t => t.Job_LocationId).HasColumnName("Job_LocationId");
            this.Property(t => t.Job_ExpLevelId).HasColumnName("Job_ExpLevelId");
            this.Property(t => t.Job_Title).HasColumnName("Job_Title");
            this.Property(t => t.Job_Designation).HasColumnName("Job_Designation");
            this.Property(t => t.Job_Description).HasColumnName("Job_Description");
            this.Property(t => t.Job_DateTime).HasColumnName("Job_DateTime");
            this.Property(t => t.Job_Status).HasColumnName("Job_Status");
        }
    }
}
