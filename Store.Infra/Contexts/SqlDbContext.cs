using Microsoft.EntityFrameworkCore;
using Store.Infra.Contexts.Mapping;
using Store.Domain.Entities;

namespace Store.Infra.Contexts
{
    public class SqlDbContext: DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            :base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
