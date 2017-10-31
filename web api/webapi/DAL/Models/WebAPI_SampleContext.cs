using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DAL.Models.Mapping;

namespace DAL.Models
{
    public partial class WebAPI_SampleContext : DbContext
    {
        static WebAPI_SampleContext()
        {
            Database.SetInitializer<WebAPI_SampleContext>(null);
        }

        public WebAPI_SampleContext()
            : base("Name=WebAPI_SampleContext")
        {
        }

        public DbSet<tbl_User> tbl_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new tbl_UserMap());
        }
    }
}
