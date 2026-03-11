using MyBooks.Core.Entities;

namespace MyBooks.Core.Repositories
{
    public interface IBibliotecaRepository
    {

        Task<int> AdicionarLivro(Biblioteca biblioteca);

        Task<List<Biblioteca>> BuscarLivroPorIdUsuario(int idUsuario);

        Task<Biblioteca?> BuscarLivroPorId(int IdLivro);

        Task UpdateLivro(Biblioteca biblioteca);

    }
}
