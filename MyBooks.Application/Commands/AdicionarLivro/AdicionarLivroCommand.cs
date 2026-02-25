using MediatR;
using MyBooks.Application.Models;

namespace MyBooks.Application.Commands.AdicionarLivro
{
    public class AdicionarLivroCommand : IRequest<ResultViewModel<int>>
    {
        public string IdExternoLivro  { get; set; }
    }
}
