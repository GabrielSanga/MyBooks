using MediatR;
using MyBooks.Application.Commands.AlterarLivroLendo;
using MyBooks.Application.Models;
using MyBooks.Core.Repositories;

namespace MyBooks.Application.Commands.AlteraLivroLido
{
    public class AlterarLivroLidoHandler : IRequestHandler<AlterarLivroLidoCommand, ResultViewModel>
    {

        private readonly IBibliotecaRepository _bibliotecaRepository;

        public AlterarLivroLidoHandler(IBibliotecaRepository bibliotecaRepository)
        {
            _bibliotecaRepository = bibliotecaRepository;
        }
        public async Task<ResultViewModel> Handle(AlterarLivroLidoCommand request, CancellationToken cancellationToken)
        {
            var livro = await _bibliotecaRepository.BuscarLivroPorId(request.IdBiblioteca);

            if (livro == null)
            {
                return ResultViewModel.Erro("Livro não encontrado.");
            }

            livro.Lido();
            await _bibliotecaRepository.UpdateLivro(livro);

            return ResultViewModel.Ok();
        }
    }
}
