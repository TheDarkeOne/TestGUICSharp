using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGUICSharp.Data
{
    public class ScheduleDbContext : DbContext
    {
        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().HasData(GetSchedules());
            base.OnModelCreating(modelBuilder);
        }

        private Schedule[] GetSchedules()
        {
            return new Schedule[]
            {
            new Schedule { Id = 1, Name = "Math Homework", Description = "Do the Math Homework for the things", Date = DateTime.Now, Time = DateTime.Now},
            new Schedule { Id = 2, Name = "Do Laundry", Description = "Need to do my laundry right now", Date = DateTime.Now, Time = DateTime.Now},
            new Schedule { Id = 3, Name = "Buy Socks", Description = "Buy New Socks", Date = DateTime.Now, Time = DateTime.Now},
            new Schedule { Id = 4, Name = "Buy Underwear", Description = "Buy New Underwear", Date = DateTime.Now, Time = DateTime.Now},
            };
        }
    }
}
