using Microsoft.EntityFrameworkCore;

namespace Blog.Model
{

    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options) { }

        public DbSet<TabUsuarioBlog> TabUsuarioBlog { get; set; }
        public DbSet<TabPost> TabPost { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabUsuarioBlog>().ToTable("tabUsuarioBlog");
            modelBuilder.Entity<TabPost>().ToTable("tabPost");

        }
    }
}

    
