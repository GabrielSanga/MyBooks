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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookService _bookService;        
        private readonly IUserSession _userSession;

        public AdicionarLivroHandler(IUnitOfWork unitOfWork, IBookService bookService, IUserSession userSession)
        {
            _unitOfWork = unitOfWork;
            _bookService = bookService;
            _userSession = userSession;
        }

        public async Task<ResultViewModel<int>> Handle(AdicionarLivroCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _unitOfWork.Usuarios.ObterPorEmail(_userSession.Email);
            if (usuario == null)
            {
                return ResultViewModel<int>.Erro("Usuário não autenticado.");
            }

            var livro = await _unitOfWork.Livros.ObterPorIdExternal(request.IdExternoLivro);
            if (livro == null)
            {
                var livroApi = await _bookService.BuscarLivro(request.IdExternoLivro);

                if (livroApi == null)
                    return ResultViewModel<int>.Erro("Livro não encontrado na base do Google.");

                livro = new Livro(livroApi.Titulo, livroApi.Descricao, livroApi.ISBN, livroApi.Autor, livroApi.Editora, livroApi.Genero, livroApi.AnoPublicacao, livroApi.URLCapa, request.IdExternoLivro);

                await _unitOfWork.Livros.Adicionar(livro);
            }

            var biblioteca = new Biblioteca(usuario.Id, livro.Id);
            await _unitOfWork.Bibliotecas.AdicionarLivro(biblioteca);

            await _unitOfWork.SaveChangesAsync();

            return ResultViewModel<int>.Ok(biblioteca.Id);
        }
    }
}
