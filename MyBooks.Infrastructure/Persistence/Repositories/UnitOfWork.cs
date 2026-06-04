using Microsoft.EntityFrameworkCore;
using MyBooks.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyBooksDBContext _dbContext;

        public UnitOfWork(MyBooksDBContext myBooksDBContext, ILivroRepository livros, IBibliotecaRepository bibliotecas, IUsuarioRepository usuarios)
        {
            _dbContext = myBooksDBContext;

            Livros = livros;
            Bibliotecas = bibliotecas;
            Usuarios = usuarios;
        }

        public ILivroRepository Livros { get; }

        public IBibliotecaRepository Bibliotecas { get; }

        public IUsuarioRepository Usuarios { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
