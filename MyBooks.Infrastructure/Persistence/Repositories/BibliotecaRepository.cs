using Microsoft.EntityFrameworkCore;
using MyBooks.Core.Entities;
using MyBooks.Core.Repositories;

namespace MyBooks.Infrastructure.Persistence.Repositories
{
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private readonly MyBooksDBContext _dbContext;

        public BibliotecaRepository(MyBooksDBContext dbContext) { 
            _dbContext = dbContext;
        }

        public async Task<int> AdicionarLivroNaBiblioteca(Biblioteca biblioteca)
        {
            await _dbContext.Bibliotecas.AddAsync(biblioteca);
            await _dbContext.SaveChangesAsync();

            return biblioteca.Id;
        }

        public async Task<List<Biblioteca>> BuscarBibliotecaPorIdUsuario(int idUsuario)
        {
            var bibliotecas = await _dbContext.Bibliotecas
                                              .Include(b => b.Livro)
                                              .Include(b => b.Usuario)
                                              .Where(b => b.IdUsuario == idUsuario)
                                              .ToListAsync();

            return bibliotecas;
        }
    }
}
