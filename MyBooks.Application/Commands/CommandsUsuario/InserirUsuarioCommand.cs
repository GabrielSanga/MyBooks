using MediatR;
using MyBooks.Application.Models;

namespace MyBooks.Application.Commands.CommandsUsuario
{
    public class InserirUsuarioCommand : IRequest<ResultViewModel<int>>
    {
        public string Nome { get;  set; }

        public string Email { get; set; }

    }
}
