using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class TaskDbContext : DbContext
    {
        private static TaskDbContext instance = null;
        public static TaskDbContext GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaskDbContext();
                }
                return instance;
            }
        }
        private TaskDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TaskDbContext>());
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
