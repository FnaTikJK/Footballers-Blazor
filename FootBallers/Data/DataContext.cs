﻿using FootBallers.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootBallers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<Footballer> Footballers => Set<Footballer>();
    }
}
