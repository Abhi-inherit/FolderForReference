using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using JobPortal.Models.Mapping;

namespace JobPortal.Models
{
    public partial class Db_JobPortalContext : DbContext
    {
        static Db_JobPortalContext()
        {
            Database.SetInitializer<Db_JobPortalContext>(null);
        }

        public Db_JobPortalContext()
            : base("Name=Db_JobPortalContext")
        {
        }

        public DbSet<tbl_Candidate> tbl_Candidate { get; set; }
        public DbSet<tbl_CandidateAppliedJobs> tbl_CandidateAppliedJobs { get; set; }
        public DbSet<tbl_Category> tbl_Category { get; set; }
        public DbSet<tbl_Employer> tbl_Employer { get; set; }
        public DbSet<tbl_EmployerManageCandidateProfile> tbl_EmployerManageCandidateProfile { get; set; }
        public DbSet<tbl_ExperienceLevel> tbl_ExperienceLevel { get; set; }
        public DbSet<tbl_Jobs> tbl_Jobs { get; set; }
        public DbSet<tbl_Location> tbl_Location { get; set; }
        public DbSet<vw_JobDetails> vw_JobDetails { get; set; }
        public DbSet<vw_ViewProfileHistory> vw_ViewProfileHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new tbl_CandidateMap());
            modelBuilder.Configurations.Add(new tbl_CandidateAppliedJobsMap());
            modelBuilder.Configurations.Add(new tbl_CategoryMap());
            modelBuilder.Configurations.Add(new tbl_EmployerMap());
            modelBuilder.Configurations.Add(new tbl_EmployerManageCandidateProfileMap());
            modelBuilder.Configurations.Add(new tbl_ExperienceLevelMap());
            modelBuilder.Configurations.Add(new tbl_JobsMap());
            modelBuilder.Configurations.Add(new tbl_LocationMap());
            modelBuilder.Configurations.Add(new vw_JobDetailsMap());
            modelBuilder.Configurations.Add(new vw_ViewProfileHistoryMap());
        }
    }
}
