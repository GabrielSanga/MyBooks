using MediatR;
using MyBooks.Application.Models;
using MyBooks.Core.Services;

namespace MyBooks.Application.Queries.BuscarLivros
{
    public class BuscarLivrosHandler : IRequestHandler<BuscarLivrosQuery, ResultViewModel<List<LivrosViewModel>>>
    {
        private readonly IBookService _bookService;
        public BuscarLivrosHandler(IBookService bookService) { 
            _bookService = bookService;
        }

        public async Task<ResultViewModel<List<LivrosViewModel>>> Handle(BuscarLivrosQuery request, CancellationToken cancellationToken)
        {
            var livros = await _bookService.BuscarLivros(request.Titulo + request.Genero + request.Autor);

            var livrosViewModel = livros.Select(l => new LivrosViewModel(l.IdExterno, l.Titulo, l.Descricao, l.ISBN, l.Autor, l.Editora, l.Genero, l.AnoPublicacao, l.URLCapa)).ToList();

            if (livrosViewModel == null) {
                return ResultViewModel<List<LivrosViewModel>>.Erro("Livros não encontrados!");
            }

            return ResultViewModel<List<LivrosViewModel>>.Ok(livrosViewModel);
        }
    }

}
