using MediatR;
using MyBooks.Application.Models;

namespace MyBooks.Application.Commands.LogarUsuario
{
    public class LogarUsuarioCommand : IRequest<ResultViewModel<LoginViewModel>>
    {
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
