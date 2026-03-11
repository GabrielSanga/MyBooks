using MyBooks.Core.Enums;

namespace MyBooks.Application.Models
{
    public class BibliotecaLivroViewModel
    {
        public BibliotecaLivroViewModel(int idBiblioteca, string idExterno, string titulo, string descricao, string iSBN, string autor, string editora, string genero, DateTime anoPublicacao, string uRLCapa, BibliotecaStatus status)
        {
            IdBiblioteca = idBiblioteca;
            IdExterno = idExterno;
            Titulo = titulo;
            Descricao = descricao;
            ISBN = iSBN;
            Autor = autor;
            Editora = editora;
            Genero = genero;
            AnoPublicacao = anoPublicacao;
            URLCapa = uRLCapa;
            Status = status;
        }

        public int IdBiblioteca { get; private set; }

        public string IdExterno { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public string ISBN { get; private set; }

        public string Autor { get; private set; }

        public string Editora { get; private set; }

        public string Genero { get; private set; }

        public DateTime AnoPublicacao { get; private set; }

        public string URLCapa { get; private set; }

        public BibliotecaStatus Status { get; private set; }
    }
}
