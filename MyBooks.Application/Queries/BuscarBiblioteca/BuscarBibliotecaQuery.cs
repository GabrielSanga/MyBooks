using MediatR;
using MyBooks.Application.Models;
using MyBooks.Core.ReadModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Application.Queries.BuscarBiblioteca
{
    public class BuscarBibliotecaQuery : IRequest<ResultViewModel<PaginationResult<BibliotecaLivroViewModel>>>
    {

        public int Page { get; set; }

    }
}
