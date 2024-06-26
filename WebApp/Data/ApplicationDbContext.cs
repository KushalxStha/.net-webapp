﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApp.Models;


namespace WebApp.Data
{
    public class ApplicationDbContext:IdentityDbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
