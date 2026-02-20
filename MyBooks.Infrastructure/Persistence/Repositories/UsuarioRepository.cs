using Microsoft.EntityFrameworkCore;
using MyBooks.Core.Entities;
using MyBooks.Core.Repositories;
using MyBooks.Infrastructure.Persistence;

namespace MyBooks.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MyBooksDBContext _dbContext;   

        public UsuarioRepository(MyBooksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Inserir(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario.Id;
        }

    }
}
