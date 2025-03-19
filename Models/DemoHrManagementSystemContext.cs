using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Demo_HR_Management_System.Models;

public partial class DemoHrManagementSystemContext : DbContext
{
    public DemoHrManagementSystemContext()
    {
    }

    public DemoHrManagementSystemContext(DbContextOptions<DemoHrManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-0CG0PP6\\SQLEXPRESS; database=Demo_HR_Management_System;trusted_connection=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.EmpCity)
                .HasMaxLength(50)
                .HasColumnName("emp_city");
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(50)
                .HasColumnName("emp_designation");
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(50)
                .HasColumnName("emp_email");
            entity.Property(e => e.EmpMobile)
                .HasMaxLength(50)
                .HasColumnName("emp_mobile");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .HasColumnName("emp_name");
            entity.Property(e => e.EmpSalary)
                .HasMaxLength(50)
                .HasColumnName("emp_salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
