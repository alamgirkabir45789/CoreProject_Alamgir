using CoreProject_Alamgir.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject_Alamgir.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicineCategory> MedicineCategories { get; set; }
        public DbSet<MedicineItem> MedicineItems { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<InternDoctor> InternDoctors { get; set; }
    }
}
