using MediatR;
using MyBooks.Application.Models;
using MyBooks.Core.Authenticate;
using MyBooks.Core.Entities;
using MyBooks.Core.ReadModels;
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
            LivroReadModel? livroApi = null;

            if (livro == null)
            {
                livroApi = await _bookService.BuscarLivro(request.IdExternoLivro);

                if (livroApi == null)
                    return ResultViewModel<int>.Erro("Livro não encontrado na base do Google.");
            }

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                if (livro == null)
                {
                    livro = new Livro(livroApi.Titulo, livroApi.Descricao, livroApi.ISBN, livroApi.Autor, livroApi.Editora, livroApi.Genero, livroApi.AnoPublicacao, livroApi.URLCapa, request.IdExternoLivro);

                    await _unitOfWork.Livros.Adicionar(livro);
                    await _unitOfWork.SaveChangesAsync();
                } 

                var biblioteca = new Biblioteca(usuario, livro);
                await _unitOfWork.Bibliotecas.AdicionarLivro(biblioteca);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();

                return ResultViewModel<int>.Ok(biblioteca.Id);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
