namespace MyBooks.Core.Entities
{
    public class Livro : BaseEntity
    {
        public Livro(string titulo, string descricao, string iSBN, string autor, string editora, string genero, DateTime anoPublicacao, string uRLCapa)
        {
            Titulo = titulo;
            Descricao = descricao;
            ISBN = iSBN;
            Autor = autor;
            Editora = editora;
            Genero = genero;
            AnoPublicacao = anoPublicacao;
            URLCapa = uRLCapa;

            Avaliacoes = [];
            Bibliotecas = [];  
        }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public string ISBN { get; private set; }

        public string Autor { get; private set; }

        public string Editora { get; private set; }

        public string Genero { get; private set; }

        public DateTime AnoPublicacao { get; private set; }

        public string URLCapa { get; private set; }

        public List<Avaliacao> Avaliacoes { get; private set; }

        public List<Biblioteca> Bibliotecas { get; private set; }

    }
}
