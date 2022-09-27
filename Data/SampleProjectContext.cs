using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleProject.Models;

    public class SampleProjectContext : DbContext
    {
        public SampleProjectContext (DbContextOptions<SampleProjectContext> options)
            : base(options)
        {
        }

         public SampleProjectContext()
         {

         }

        public DbSet<SampleProject.Models.UserRegistration> UserRegistration { get; set; } = default!;
    }
