﻿using Guessing_Game.Models;
using Microsoft.EntityFrameworkCore;

namespace Guessing_Game.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }

    
}
