using MediatR;
using MyBooks.Application.Commands.AlteraLivroLido;
using MyBooks.Application.Models;
using MyBooks.Core.Repositories;

namespace MyBooks.Application.Commands.AlterarLivroCancelado
{
    public class AlteraLivroCanceladoHandler : IRequestHandler<AlteraLivroCanceladoCommand, ResultViewModel>
    {
        private readonly IBibliotecaRepository _bibliotecaRepository;

        public AlteraLivroCanceladoHandler(IBibliotecaRepository bibliotecaRepository)
        {
            _bibliotecaRepository = bibliotecaRepository;
        }

        public async Task<ResultViewModel> Handle(AlteraLivroCanceladoCommand request, CancellationToken cancellationToken)
        {
            var livro = await _bibliotecaRepository.BuscarLivroPorId(request.IdBiblioteca);

            if (livro == null)
            {
                return ResultViewModel.Erro("Livro não encontrado.");
            }

            livro.Cancelado();
            await _bibliotecaRepository.UpdateLivro(livro);

            return ResultViewModel.Ok();
        }
    }
}
