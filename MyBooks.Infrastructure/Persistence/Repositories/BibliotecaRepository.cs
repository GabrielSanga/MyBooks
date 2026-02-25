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
    }
}
