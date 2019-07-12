namespace Cobiax.Models.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<ContactU> ContactUs { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MainSlider> MainSliders { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<SliderForProject> SliderForProjects { get; set; }
        public virtual DbSet<SliderForService> SliderForServices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.SliderForProjects)
                .WithOptional(e => e.Project)
                .HasForeignKey(e => e.Project_Id);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.SliderForProjects1)
                .WithOptional(e => e.Project1)
                .HasForeignKey(e => e.Project_Id);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.SliderForProjects2)
                .WithOptional(e => e.Project2)
                .HasForeignKey(e => e.Project_Id);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.SliderForServices)
                .WithOptional(e => e.Service)
                .HasForeignKey(e => e.Service_Id);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.SliderForServices1)
                .WithOptional(e => e.Service1)
                .HasForeignKey(e => e.Service_Id);
        }
    }
}
