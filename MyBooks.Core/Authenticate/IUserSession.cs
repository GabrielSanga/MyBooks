using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Core.Authenticate
{
    public interface IUserSession
    {

        string Email { get;}
        bool Autenticado { get; }

    }
}
