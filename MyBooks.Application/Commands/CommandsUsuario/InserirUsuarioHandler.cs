using MediatR;
using MyBooks.Application.Models;
using MyBooks.Core.Entities;
using MyBooks.Core.Repositories;

namespace MyBooks.Application.Commands.CommandsUsuario
{
    public class InserirUsuarioHandler : IRequestHandler<InserirUsuarioCommand, ResultViewModel<int>>
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public InserirUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResultViewModel<int>> Handle(InserirUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.Nome, request.Email);

            await _usuarioRepository.Inserir(usuario);

            return ResultViewModel<int>.Ok(usuario.Id);
        }
    }

}
