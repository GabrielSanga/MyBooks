using MediatR;
using MyBooks.Application.Models;

namespace MyBooks.Application.Queries.BuscarLivros
{
    public class BuscarLivrosQuery : IRequest<ResultViewModel<List<LivrosViewModel>>>
    {
        public BuscarLivrosQuery(string titulo, string autor, string genero)
        {
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
        }

        public string  Titulo { get;  set; }

        public string  Autor { get;  set; }

        public string  Genero { get; set; }

    }
}
