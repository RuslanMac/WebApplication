using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProjectModel> Projects { get; set; } 
        public DbSet<TaskModel> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }
    }
}
