using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class tbl_UserMap : EntityTypeConfiguration<tbl_User>
    {
        public tbl_UserMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(100);

            this.Property(t => t.email)
                .HasMaxLength(50);

            this.Property(t => t.phone)
                .HasMaxLength(15);

            this.Property(t => t.address)
                .HasMaxLength(500);

            this.Property(t => t.location)
                .HasMaxLength(500);

            this.Property(t => t.gender)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.username)
                .HasMaxLength(50);

            this.Property(t => t.password)
                .HasMaxLength(50);

            this.Property(t => t.isActive)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("tbl_User");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.phone).HasColumnName("phone");
            this.Property(t => t.address).HasColumnName("address");
            this.Property(t => t.location).HasColumnName("location");
            this.Property(t => t.gender).HasColumnName("gender");
            this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.createdDate).HasColumnName("createdDate");
            this.Property(t => t.lastModified).HasColumnName("lastModified");
            this.Property(t => t.isActive).HasColumnName("isActive");
        }
    }
}
