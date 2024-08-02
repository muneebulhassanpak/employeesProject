using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeesProject.Models
{
    public partial class employeeDatabaseContext : DbContext
    {
        public employeeDatabaseContext()
        {
        }

        public employeeDatabaseContext(DbContextOptions<employeeDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachement> Attachements { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Employeestate> Employeestates { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=ConnectionStrings:WebApiDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachement>(entity =>
            {
                entity.ToTable("Attachement");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('file_id_seq'::regclass)");

                entity.Property(e => e.Basecode).HasColumnName("basecode");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Size)
                    .HasPrecision(10, 2)
                    .HasColumnName("size");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attachements)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("file_employee_id_fkey");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Dob).HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Experienceend).HasColumnName("experienceend");

                entity.Property(e => e.Experiencestart).HasColumnName("experiencestart");

                entity.Property(e => e.Gender)
                    .HasMaxLength(15)
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Rate)
                    .HasPrecision(10, 2)
                    .HasColumnName("rate");

                entity.Property(e => e.RateFlag).HasColumnName("rate_flag");

                entity.Property(e => e.Yearsofexperience)
                    .HasMaxLength(255)
                    .HasColumnName("yearsofexperience");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("employees_client_id_fkey");
            });

            modelBuilder.Entity<Employeestate>(entity =>
            {
                entity.ToTable("employeestate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Employeestates)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("employeestate_employee_id_fkey");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Employeestates)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("employeestate_state_id_fkey");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
