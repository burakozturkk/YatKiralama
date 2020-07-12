using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YatKiralama.Models;

namespace YatKiralama.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Yat> Yatlar { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Saatler> Saatler { get; set; }
        public DbSet<Kirala> Kirala { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
