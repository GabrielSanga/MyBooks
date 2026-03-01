using MediatR;
using MyBooks.Application.Models;
using MyBooks.Core.Authenticate;
using MyBooks.Core.Repositories;

namespace MyBooks.Application.Queries.BuscarBiblioteca
{
    public class BsucarBibliotecaHandler : IRequestHandler<BuscarBibliotecaQuery, ResultViewModel<List<BibliotecaLivroViewModel>>>
    {
        private readonly IBibliotecaRepository _bibliotecaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUserSession _userSession;

        public BsucarBibliotecaHandler(IBibliotecaRepository bibliotecaRepository, IUsuarioRepository usuarioRepository, IUserSession userSession)
        {
            _bibliotecaRepository = bibliotecaRepository;
            _usuarioRepository = usuarioRepository;
            _userSession = userSession;
        }

        public async Task<ResultViewModel<List<BibliotecaLivroViewModel>>> Handle(BuscarBibliotecaQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorEmail(_userSession.Email);

            if (usuario == null)
            {
                return ResultViewModel<List<BibliotecaLivroViewModel>>.Erro("Usuário não autenticado.");
            }

            var bibliotecas = await _bibliotecaRepository.BuscarBibliotecaPorIdUsuario(usuario.Id);

            var model = bibliotecas.Select(b => new BibliotecaLivroViewModel(b.Livro.IdExterno, b.Livro.Titulo, b.Livro.Descricao, b.Livro.ISBN, b.Livro.Autor, b.Livro.Editora, b.Livro.Genero, b.Livro.AnoPublicacao, b.Livro.URLCapa, b.Status)).ToList();

            return ResultViewModel<List<BibliotecaLivroViewModel>>.Ok(model);
        }
    }
}
