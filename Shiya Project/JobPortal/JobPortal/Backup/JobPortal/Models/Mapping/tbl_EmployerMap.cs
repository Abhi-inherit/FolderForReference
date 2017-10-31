using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JobPortal.Models.Mapping
{
    public class tbl_EmployerMap : EntityTypeConfiguration<tbl_Employer>
    {
        public tbl_EmployerMap()
        {
            // Primary Key
            this.HasKey(t => t.Emp_Id);

            // Properties
            this.Property(t => t.Emp_Name)
                .HasMaxLength(50);

            this.Property(t => t.Emp_ContactPersonName)
                .HasMaxLength(50);

            this.Property(t => t.Emp_EmailId)
                .HasMaxLength(50);

            this.Property(t => t.Emp_MobileNumber)
                .HasMaxLength(50);

            this.Property(t => t.Emp_Place)
                .HasMaxLength(50);

            this.Property(t => t.Emp_LogoImage)
                .HasMaxLength(500);

            this.Property(t => t.Emp_UserName)
                .HasMaxLength(50);

            this.Property(t => t.Emp_Password)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tbl_Employer");
            this.Property(t => t.Emp_Id).HasColumnName("Emp_Id");
            this.Property(t => t.Emp_Name).HasColumnName("Emp_Name");
            this.Property(t => t.Emp_Address).HasColumnName("Emp_Address");
            this.Property(t => t.Emp_ContactPersonName).HasColumnName("Emp_ContactPersonName");
            this.Property(t => t.Emp_EmailId).HasColumnName("Emp_EmailId");
            this.Property(t => t.Emp_MobileNumber).HasColumnName("Emp_MobileNumber");
            this.Property(t => t.Emp_Place).HasColumnName("Emp_Place");
            this.Property(t => t.Emp_LogoImage).HasColumnName("Emp_LogoImage");
            this.Property(t => t.Emp_DateTime).HasColumnName("Emp_DateTime");
            this.Property(t => t.Emp_Status).HasColumnName("Emp_Status");
            this.Property(t => t.Emp_UserName).HasColumnName("Emp_UserName");
            this.Property(t => t.Emp_Password).HasColumnName("Emp_Password");
        }
    }
}
