using MediatR;

namespace MyBooks.Application.Commands.CommandsUsuario
{
    public class InserirUsuarioCommand : IRequest<int>
    {
        public string Nome { get;  set; }

        public string Email { get; set; }

    }
}
