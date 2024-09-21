using FaylYükləmə.Models;
using Microsoft.EntityFrameworkCore;

namespace FaylYükləmə.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
    }
}
