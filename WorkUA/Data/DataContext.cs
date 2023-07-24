using Microsoft.EntityFrameworkCore;
using WorkUA.Models;

namespace WorkUA.Data {
    public class DataContext : DbContext {
        public DbSet<Applicant>? Applicants;

        public DbSet<City>? Cities;

        public DbSet<Employer>? Employers;

        public DbSet<Profession>? Professions;

        public DbSet<Vacancy>? Vacancies;

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Applicant>()
                .HasOne(a => a.City)
                .WithMany(c => c.Applicants)
                .HasForeignKey(a => a.CityId);
            modelBuilder.Entity<Applicant>()
                .HasOne(a => a.Profession)
                .WithMany(p => p.Applicants)
                .HasForeignKey(a => a.ProfessionId);
            modelBuilder.Entity<Employer>()
                .HasOne(a => a.City)
                .WithMany(c => c.Employers)
                .HasForeignKey(p => p.CityId);
            modelBuilder.Entity<Vacancy>()
                .HasOne(v => v.Employer)
                .WithMany(c => c.Vacancies)
                .HasForeignKey(p => p.EmployerId);
            modelBuilder.Entity<Vacancy>()
                .HasOne(v => v.Profession)
                .WithMany(c => c.Vacancies)
                .HasForeignKey(p => p.ProfessionId);
        }

        public DbSet<Applicant>? Applicant { get; set; }

        public DbSet<Vacancy>? Vacancy { get; set; }
    }
}