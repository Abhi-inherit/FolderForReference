using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JobPortal.Models.Mapping
{
    public class tbl_ExperienceLevelMap : EntityTypeConfiguration<tbl_ExperienceLevel>
    {
        public tbl_ExperienceLevelMap()
        {
            // Primary Key
            this.HasKey(t => t.ExperienceId);

            // Properties
            this.Property(t => t.ExperienceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ExperienceLevel)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tbl_ExperienceLevel");
            this.Property(t => t.ExperienceId).HasColumnName("ExperienceId");
            this.Property(t => t.ExperienceLevel).HasColumnName("ExperienceLevel");
        }
    }
}
