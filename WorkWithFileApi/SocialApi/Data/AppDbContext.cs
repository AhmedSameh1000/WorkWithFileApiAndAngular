using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkWithFiles.Api.Models;
using ZwajApp.api.Models;

namespace ZwajApp.api.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<CloudinaryPhoto> CloudinaryPhotos { get; set; }
    }
}