using Microsoft.EntityFrameworkCore;
using VendendoPecas.Models;

namespace VendendoPecas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<VendasModel> Vendas { get; set; }
    }
}
