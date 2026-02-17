using Microsoft.EntityFrameworkCore;
using MyBooks.Core.Entities;

namespace MyBooks.Infrastructure.Persistence
{
    public class MyBooksDBContext : DbContext
    {

        public MyBooksDBContext(DbContextOptions<MyBooksDBContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Biblioteca> Bibliotecas { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>(e =>
            {
                e.HasKey(u => u.Id);
            });

            builder.Entity<Livro>(e =>
            {
                e.HasKey(l => l.Id);
            });

            builder.Entity<Biblioteca>(e =>
            {
                e.HasKey(b => b.Id);

                e.HasOne(b => b.Usuario).WithMany(u => u.Bibliotecas).HasForeignKey(b => b.IdUsuario);
                e.HasOne(b => b.Livro).WithMany(l => l.Bibliotecas).HasForeignKey(b => b.IdLivro);
            });

            builder.Entity<Avaliacao>(e =>
            {
                e.HasKey(a => a.Id);

                e.HasOne(a => a.Usuario).WithMany(u => u.Avaliacoes).HasForeignKey(a => a.IdUsuario);
                e.HasOne(a => a.Livro).WithMany(l => l.Avaliacoes).HasForeignKey(a => a.IdLivro);
            });

            base.OnModelCreating(builder);
        }
    }
}
