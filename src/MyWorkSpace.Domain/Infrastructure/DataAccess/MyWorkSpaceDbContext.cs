using Microsoft.EntityFrameworkCore;
using MyWorkSpace.Domain.AggregateRoots.UserAggregateRoot;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkSpace.Domain.Infrastructure.DataAccess
{
    public class MyWorkSpaceDbContext : DbContext
    {
        DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MyWorkSpace.db");
        }
    }
}
