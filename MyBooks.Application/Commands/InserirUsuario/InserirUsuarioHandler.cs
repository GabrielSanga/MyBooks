using MediatR;
using MyBooks.Application.Models;
using MyBooks.Core.Authenticate;
using MyBooks.Core.Entities;
using MyBooks.Core.Repositories;

namespace MyBooks.Application.Commands.InserirUsuario
{
    public class InserirUsuarioHandler : IRequestHandler<InserirUsuarioCommand, ResultViewModel<int>>
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;

        public InserirUsuarioHandler(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService; 
        }

        public async Task<ResultViewModel<int>> Handle(InserirUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.Nome, request.Email, _authService.CalcularHash(request.Senha));

            await _usuarioRepository.Inserir(usuario);

            return ResultViewModel<int>.Ok(usuario.Id);
        }
    }

}
