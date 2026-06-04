namespace MyBooks.Core.Repositories
{
    public interface IUnitOfWork
    {
        ILivroRepository Livros { get; }

        IBibliotecaRepository Bibliotecas { get; }

        IUsuarioRepository Usuarios { get; }

        Task BeginTransactionAsync();

        Task<int> SaveChangesAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();

    }
}
