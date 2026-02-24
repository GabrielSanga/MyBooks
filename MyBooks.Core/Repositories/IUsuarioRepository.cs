using MyBooks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Core.Repositories
{
    public interface IUsuarioRepository
    {

        Task<int> Inserir(Usuario usuario);

        Task<Usuario?> ObterPorEmail(string email);

        Task<Usuario?> ObterPorEmailESenha(string email, string hashSenha);

    }
}
