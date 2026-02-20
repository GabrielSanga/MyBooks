using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Application.Models
{
    public class ResultViewModel
    {
        public ResultViewModel(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; private set; }

        public string Mensagem { get; private set; }

        public static ResultViewModel Ok()
        {
            return new ResultViewModel(true, "Operação realizada com sucesso.");
        }

        public static ResultViewModel Erro(string mensagem)
        {
            return new ResultViewModel(false, mensagem);
        }
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? objeto, bool sucesso, string mensagem) : base(sucesso, mensagem)
        {
            Objeto = objeto;
        }

        public T? Objeto { get; private set; }

        public static ResultViewModel<T> Ok(T? objeto)
        {
            return new ResultViewModel<T>(objeto, true, "");
        }

        public static ResultViewModel<T> Erro(string mensagem)
        {
            return new ResultViewModel<T>(default, false, mensagem);
        }

    }

}
