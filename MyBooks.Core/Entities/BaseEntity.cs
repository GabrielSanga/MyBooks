using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            DataCriacao = DateTime.Now;
            Deletado = false;
        }

        public int Id { get; protected set; }

        public DateTime DataCriacao { get; protected set; }

        public bool Deletado { get; protected set; }

        public void SetDeletado(bool deletado)
        {
            Deletado = deletado;
        }

    }
}
