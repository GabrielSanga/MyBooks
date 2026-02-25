using MediatR;
using MyBooks.Application.Models;
using MyBooks.Core.Authenticate;
using MyBooks.Core.Entities;
using MyBooks.Core.Repositories;
using MyBooks.Core.Services;

namespace MyBooks.Application.Commands.AdicionarLivro
{
    public class AdicionarLivroHandler : IRequestHandler<AdicionarLivroCommand, ResultViewModel<int>>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IBibliotecaRepository _bibliotecaRepository;
        private readonly IBookService _bookService;        
        private readonly IUserSession _userSession;
        private readonly IUsuarioRepository _usuarioRepository;

        public AdicionarLivroHandler(ILivroRepository livroRepository, IBibliotecaRepository bibliotecaRepository, IBookService bookService, IUserSession userSession, IUsuarioRepository usuarioRepository)
        {
            _livroRepository = livroRepository;
            _bibliotecaRepository = bibliotecaRepository;
            _bookService = bookService;
            _userSession = userSession;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResultViewModel<int>> Handle(AdicionarLivroCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorEmail(_userSession.Email);
            if (usuario == null)
            {
                return ResultViewModel<int>.Erro("Usuário não encontrado.");
            }

            var livro = await _livroRepository.ObterPorIdExternal(request.IdExternoLivro);
            if (livro == null)
            {
                var livroApi = await _bookService.BuscarLivro(request.IdExternoLivro);

                if (livroApi == null)
                    return ResultViewModel<int>.Erro("Livro não encontrado na base do Google.");

                livro = new Livro(livroApi.Titulo, livroApi.Descricao, livroApi.ISBN, livroApi.Autor, livroApi.Editora, livroApi.Genero, livroApi.AnoPublicacao, livroApi.URLCapa, request.IdExternoLivro);

                await _livroRepository.Adicionar(livro);
            }

            var biblioteca = new Biblioteca(usuario.Id, livro.Id);
            await _bibliotecaRepository.AdicionarLivroNaBiblioteca(biblioteca);

            return ResultViewModel<int>.Ok(biblioteca.Id);
        }
    }
}
