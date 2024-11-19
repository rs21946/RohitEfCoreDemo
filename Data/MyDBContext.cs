using Microsoft.EntityFrameworkCore;
using RohitEFCoreDemo.Models;

namespace RohitEFCoreDemo.Data
{
    
    public class MyDBContext : DbContext
    {
        // Constructor
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        // DbSet properties represent tables in your database

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Fluent API configuration can go here if needed
        //}

        public DbSet<Student> students { get; set; }
        public DbSet<SubjectModel> subjects { get; set; }
    }
}

