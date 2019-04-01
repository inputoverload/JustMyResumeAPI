using Microsoft.EntityFrameworkCore;
using JustMyResumeApi.Models;

namespace JustMyResumeApi.Data
{
    public class JustMyResumeContext : DbContext
    {
        public JustMyResumeContext(DbContextOptions<JustMyResumeContext> options) : 
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<EducationItem> EducationItems { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<TechSkill> TechSkills { get; set; }
    }
}
