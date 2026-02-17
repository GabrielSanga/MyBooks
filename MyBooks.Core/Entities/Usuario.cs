using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;

            Avaliacoes = [];
            Bibliotecas = [];
        }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public List<Avaliacao> Avaliacoes { get; private set; }

        public List<Biblioteca> Bibliotecas { get; private set; }

    }
}
