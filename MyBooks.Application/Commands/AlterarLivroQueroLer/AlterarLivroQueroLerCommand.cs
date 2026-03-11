using MediatR;
using MyBooks.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Application.Commands.AlterarLivroQueroLer
{
    public class AlterarLivroQueroLerCommand : IRequest<ResultViewModel>
    {
        public AlterarLivroQueroLerCommand(int idBiblioteca)
        {
            IdBiblioteca = idBiblioteca;
        }

        public int IdBiblioteca { get; private set; }
    }
}
