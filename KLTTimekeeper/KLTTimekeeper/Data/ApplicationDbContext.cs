using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KLTTimekeeper.Models;

namespace KLTTimekeeper.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Project { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<KLTTimekeeper.Models.Group> Group { get; set; }

        public DbSet<KLTTimekeeper.Models.TimeCard> TimeCard { get; set; }

        public DbSet<KLTTimekeeper.Models.Course> Course { get; set; }

        public DbSet<KLTTimekeeper.Models.CourseMember> CourseMember { get; set; }

        public DbSet<KLTTimekeeper.Models.GroupMember> GroupMember { get; set; }

        public DbSet<KLTTimekeeper.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}
