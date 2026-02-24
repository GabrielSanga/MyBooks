using MediatR;
using MyBooks.Application.Models;
using MyBooks.Core.Authenticate;
using MyBooks.Core.Repositories;

namespace MyBooks.Application.Commands.LogarUsuario
{
    public class LogarUsuarioHandler : IRequestHandler<LogarUsuarioCommand, ResultViewModel<LoginViewModel>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;

        public LogarUsuarioHandler(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService;
        }

        public async Task<ResultViewModel<LoginViewModel>> Handle(LogarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorEmailESenha(request.Email, _authService.CalcularHash(request.Senha));

            if (usuario == null)
            {
                return ResultViewModel<LoginViewModel>.Erro("Credenciais inválidas!");
            }

            var token = _authService.GerarToken(request.Email);

            return ResultViewModel<LoginViewModel>.Ok(new LoginViewModel(token));
        }
    }

}
