using MyBooks.Core.Entities;
using MyBooks.Core.ReadModels;

namespace MyBooks.Core.Repositories
{
    public interface IBibliotecaRepository
    {

        Task<int> AdicionarLivro(Biblioteca biblioteca);

        Task<PaginationResult<Biblioteca>> BuscarLivroPorIdUsuario(int idUsuario, int page = 1);

        Task<Biblioteca?> BuscarLivroPorId(int IdLivro);

        Task UpdateLivro(Biblioteca biblioteca);

    }
}
