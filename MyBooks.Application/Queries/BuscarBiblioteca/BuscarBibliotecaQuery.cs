using MediatR;
using MyBooks.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Application.Queries.BuscarBiblioteca
{
    public class BuscarBibliotecaQuery : IRequest<ResultViewModel<List<BibliotecaLivroViewModel>>>
    {
    }
}
