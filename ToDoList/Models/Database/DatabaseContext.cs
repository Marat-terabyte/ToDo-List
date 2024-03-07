using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DatabaseTest.Model.Database
{
    internal class DatabaseContext : DbContext
    {
        private string _connectionString = "Data Source=Tasks.db";

        public DbSet<ToDoTask> Tasks { get; set; }
        
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }
    }
}
