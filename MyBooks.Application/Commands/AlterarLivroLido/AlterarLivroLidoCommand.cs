using MediatR;
using MyBooks.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Application.Commands.AlteraLivroLido
{
    public class AlterarLivroLidoCommand : IRequest<ResultViewModel>
    {
        public AlterarLivroLidoCommand(int idBiblioteca)
        {
            IdBiblioteca = idBiblioteca;
        }

        public int IdBiblioteca { get; private set; }
    }
}
