using MyBooks.Core.Entities;

namespace MyBooks.Core.Repositories
{
    public interface ILivroRepository
    {

        Task<Livro?> ObterPorIdExternal(string IdExternal);

        Task<int> Adicionar(Livro livro);

    }
}
