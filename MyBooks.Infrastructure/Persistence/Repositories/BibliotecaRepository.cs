using Microsoft.EntityFrameworkCore;
using MyBooks.Core.Entities;
using MyBooks.Core.ReadModels;
using MyBooks.Core.Repositories;
using MyBooks.Infrastructure.Persistence.Extensions;

namespace MyBooks.Infrastructure.Persistence.Repositories
{
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private const int PAGE_SIZE = 2;

        private readonly MyBooksDBContext _dbContext;

        public BibliotecaRepository(MyBooksDBContext dbContext) { 
            _dbContext = dbContext;
        }

        public async Task<int> AdicionarLivro(Biblioteca biblioteca)
        {
            await _dbContext.Bibliotecas.AddAsync(biblioteca);
            await _dbContext.SaveChangesAsync();

            return biblioteca.Id;
        }

        public async Task<Biblioteca?> BuscarLivroPorId(int IdLivro)
        {
            var biblioteca = await _dbContext.Bibliotecas
                             .Include(b => b.Livro)
                             .Include(b => b.Usuario)
                             .FirstOrDefaultAsync(b => b.IdLivro == IdLivro);

            return biblioteca;
        }

        public async Task<PaginationResult<Biblioteca>> BuscarLivroPorIdUsuario(int idUsuario, int page = 1)
        {
            var bibliotecas = await _dbContext.Bibliotecas
                                              .Include(b => b.Livro)
                                              .Include(b => b.Usuario)
                                              .Where(b => b.IdUsuario == idUsuario)
                                              .GetPaged(page, PAGE_SIZE);

            return bibliotecas;
        }

        public async Task UpdateLivro(Biblioteca biblioteca)
        {
            _dbContext.Bibliotecas.Update(biblioteca);
            await _dbContext.SaveChangesAsync();
        }
    }
}
