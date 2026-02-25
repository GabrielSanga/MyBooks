using MyBooks.Core.Entities;
using MyBooks.Core.ReadModels;

namespace MyBooks.Core.Services
{
    public interface IBookService
    {
        Task<List<LivroReadModel>> BuscarLivros(string filtro);

        Task<LivroReadModel?> BuscarLivro(string idExternal);
    }
}
