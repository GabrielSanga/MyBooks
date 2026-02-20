using MyBooks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Core.Repositories
{
    public interface IUsuarioRepository
    {

        Task<int> Inserir(Usuario usuario);

    }
}
