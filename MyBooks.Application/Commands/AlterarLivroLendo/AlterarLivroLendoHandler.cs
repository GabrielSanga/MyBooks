using MediatR;
using MyBooks.Application.Commands.AlterarLivroQueroLer;
using MyBooks.Application.Models;
using MyBooks.Core.Repositories;

namespace MyBooks.Application.Commands.AlterarLivroLendo
{
    public class AlterarLivroLendoHandler : IRequestHandler<AlterarLivroLendoCommand, ResultViewModel>
    {
        private readonly IBibliotecaRepository _bibliotecaRepository;

        public AlterarLivroLendoHandler(IBibliotecaRepository bibliotecaRepository)
        {
            _bibliotecaRepository = bibliotecaRepository;
        }

        public async Task<ResultViewModel> Handle(AlterarLivroLendoCommand request, CancellationToken cancellationToken)
        {
            var livro = await _bibliotecaRepository.BuscarLivroPorId(request.IdBiblioteca);

            if (livro == null)
            {
                return ResultViewModel.Erro("Livro não encontrado.");
            }

            livro.Lendo();
            await _bibliotecaRepository.UpdateLivro(livro);

            return ResultViewModel.Ok();
        }
    }
}
