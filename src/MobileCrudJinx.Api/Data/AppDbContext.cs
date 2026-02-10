using Microsoft.EntityFrameworkCore;
using MobileCrudJinx.Api.Models;

namespace MobileCrudJinx.Api.Data
{
    public class AppDbContext : DbContext
    {
        private DbSet<Produto> produtos;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos  => Set<Produto>();


    }
}
