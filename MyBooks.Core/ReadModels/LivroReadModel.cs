namespace MyBooks.Core.ReadModels
{
    public record LivroReadModel
    {
        public string IdExterno { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string ISBN { get; set; }

        public string Autor { get; set; }

        public string Editora { get; set; }

        public string Genero { get; set; }

        public DateTime AnoPublicacao { get; set; }

        public string URLCapa { get; set; }
    }
}
