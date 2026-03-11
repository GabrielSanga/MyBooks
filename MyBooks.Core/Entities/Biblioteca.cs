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

        public void QueroLer()
        {
            Status = BibliotecaStatus.QueroLer;
        }

        public void Lendo()
        {
            if (Status == BibliotecaStatus.Cancelado)
                throw new InvalidOperationException("O livro não deve estar 'Cancelado' para ser marcado como 'Lendo'.");

            Status = BibliotecaStatus.Lendo;
        }

        public void Lido()
        {
            if (Status != BibliotecaStatus.Lendo)
                throw new InvalidOperationException("O livro deve estar no status 'Lendo' para ser marcado como 'Lido'.");

            Status = BibliotecaStatus.Lido;
        }

        public void Cancelado()
        {
            Status = BibliotecaStatus.Cancelado;
        }

    }
}
