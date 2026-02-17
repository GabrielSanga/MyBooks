using MyBooks.Core.Enums;

namespace MyBooks.Core.Entities
{
    public class Biblioteca : BaseEntity
    {
        public Biblioteca(int idUsuario, int idLivro)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;

            Status = BibliotecaStatus.QueroLer;
        }

        public int IdUsuario { get; private set; }

        public Usuario Usuario { get; private set; }

        public int IdLivro{ get; private set; }

        public Livro Livro { get; private set; }

        public BibliotecaStatus Status { get; private set; }

    }
}
