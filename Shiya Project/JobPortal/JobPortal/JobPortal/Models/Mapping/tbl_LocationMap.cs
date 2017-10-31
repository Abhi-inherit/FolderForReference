using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JobPortal.Models.Mapping
{
    public class tbl_LocationMap : EntityTypeConfiguration<tbl_Location>
    {
        public tbl_LocationMap()
        {
            // Primary Key
            this.HasKey(t => t.LocationId);

            // Properties
            this.Property(t => t.LocationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LocationName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tbl_Location");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.LocationName).HasColumnName("LocationName");
        }
    }
}
