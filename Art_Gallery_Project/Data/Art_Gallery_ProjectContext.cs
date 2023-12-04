using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Art_Gallery_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Art_Gallery_Project.Data
{
    public class Art_Gallery_ProjectContext : IdentityDbContext<IdentityUser>
    {
        public Art_Gallery_ProjectContext(DbContextOptions<Art_Gallery_ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }

        public DbSet<Art_Gallery_Project.Models.Artist> Artist { get; set; } = default!;

        public DbSet<Art_Gallery_Project.Models.ArtWork> ArtWork { get; set; } = default!;


        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "1" },
                new IdentityRole() { Name = "Artist", NormalizedName = "ARTIST", ConcurrencyStamp = "2" },
                new IdentityRole() { Name = "Customer", NormalizedName = "CUSTOMER", ConcurrencyStamp = "3" },
                new IdentityRole() { Name = "Gallery_Owner", NormalizedName = "GALLERY_OWNER", ConcurrencyStamp = "4" }
            );
        }
    }
}