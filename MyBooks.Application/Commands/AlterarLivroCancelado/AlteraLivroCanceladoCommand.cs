using MediatR;
using MyBooks.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Application.Commands.AlterarLivroCancelado
{
    public class AlteraLivroCanceladoCommand : IRequest<ResultViewModel>
    {
        public AlteraLivroCanceladoCommand(int idBiblioteca)
        {
            IdBiblioteca = idBiblioteca;
        }

        public int IdBiblioteca { get; private set; }
    }
}
