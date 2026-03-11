using MediatR;
using MyBooks.Application.Models;
using MyBooks.Core.Repositories;

namespace MyBooks.Application.Commands.AlterarLivroQueroLer
{
    public class AlterarLivroQueroLerHandler : IRequestHandler<AlterarLivroQueroLerCommand, ResultViewModel>
    {
        private readonly IBibliotecaRepository _bibliotecaRepository;

        public AlterarLivroQueroLerHandler(IBibliotecaRepository bibliotecaRepository)
        {
            _bibliotecaRepository = bibliotecaRepository;   
        }

        public async Task<ResultViewModel> Handle(AlterarLivroQueroLerCommand request, CancellationToken cancellationToken)
        {
            var livro = await _bibliotecaRepository.BuscarLivroPorId(request.IdBiblioteca);

            if (livro == null)
            {
                return ResultViewModel.Erro("Livro não encontrado.");
            }

            livro.QueroLer();
            await _bibliotecaRepository.UpdateLivro(livro);

            return ResultViewModel.Ok();
        }
    }
}
