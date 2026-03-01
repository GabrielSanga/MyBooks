using MyBooks.Core.Entities;

namespace MyBooks.Core.Repositories
{
    public interface IBibliotecaRepository
    {

        Task<int> AdicionarLivroNaBiblioteca(Biblioteca biblioteca);

        Task<List<Biblioteca>> BuscarBibliotecaPorIdUsuario(int idUsuario);

    }
}
