using Microsoft.EntityFrameworkCore;
using MyBooks.Core.Entities;
using MyBooks.Core.Repositories;

namespace MyBooks.Infrastructure.Persistence.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly MyBooksDBContext _dbContext;
        
        public LivroRepository(MyBooksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Adicionar(Livro livro)
        {
            await _dbContext.Livros.AddAsync(livro);
            return livro.Id;
        }

        public async Task<Livro?> ObterPorIdExternal(string IdExternal)
        {
            return await _dbContext.Livros.SingleOrDefaultAsync(l => l.IdExterno == IdExternal);
        }
    }
}
