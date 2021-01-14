using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Stave.Models;

namespace Stave
{
    public class StaveContext : DbContext
    {
        public StaveContext(DbContextOptions <StaveContext> options) : base(options) {}
        
        public DbSet<User> Users {get; set;}
        public DbSet<Session> Sessions {get; set;}
    }
}