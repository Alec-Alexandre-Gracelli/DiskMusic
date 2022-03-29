using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DiskMusic.Models;

namespace DiskMusic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DiskMusic.Models.Album> Albuns { get; set; }
        public DbSet<DiskMusic.Models.Musica> Musicas { get; set; }
    }
}