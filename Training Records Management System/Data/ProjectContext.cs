using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ICT_TRMS.Models;

namespace Training_Records_Management_System.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<ICT_TRMS.Models.Subject>? Subject { get; set; }

        public DbSet<ICT_TRMS.Models.Student>? Student { get; set; }
    }
}
