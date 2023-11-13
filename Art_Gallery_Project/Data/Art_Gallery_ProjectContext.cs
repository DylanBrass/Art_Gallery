using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Art_Gallery_Project.Models;

namespace Art_Gallery_Project.Data
{
    public class Art_Gallery_ProjectContext : DbContext
    {
        public Art_Gallery_ProjectContext (DbContextOptions<Art_Gallery_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Art_Gallery_Project.Models.Artist> Artist { get; set; } = default!;

        public DbSet<Art_Gallery_Project.Models.ArtWork> ArtWork { get; set; } = default!;

        public DbSet<Art_Gallery_Project.Models.Exhibition> Exhibition { get; set; } = default!;
    }
}
