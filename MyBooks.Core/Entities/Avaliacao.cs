namespace MyBooks.Core.Entities
{
    public class Avaliacao : BaseEntity
    {
        public Avaliacao(double nota, string descricao, int idUsuario, int idLivro)
        {
            Nota = nota;
            Descricao = descricao;
            IdUsuario = idUsuario;
            IdLivro = idLivro;
        }

        public double Nota { get; private set; }

        public string Descricao { get; private set; }

        public int IdUsuario { get; private set; }

        public Usuario Usuario { get; private set; }

        public int IdLivro { get; private set; }

        public Livro Livro { get; private set; }    

    }
}
