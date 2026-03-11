using MediatR;
using MyBooks.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Application.Commands.AlterarLivroLendo
{
    public class AlterarLivroLendoCommand : IRequest<ResultViewModel>
    {
        public AlterarLivroLendoCommand(int idBiblioteca)
        {
            IdBiblioteca = idBiblioteca;
        }

        public int IdBiblioteca { get; private set; }
    }
}
