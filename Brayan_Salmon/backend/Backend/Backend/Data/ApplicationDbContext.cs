using Microsoft.EntityFrameworkCore;
using Backend.Models;
using System.Collections.Generic;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Input> Inputs { get; set; }
    }
}
