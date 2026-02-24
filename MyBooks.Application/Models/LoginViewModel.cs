using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Application.Models
{
    public class LoginViewModel
    {
        public LoginViewModel(string token)
        {
            Token = token;
        }

        public string Token { get; set; }

    }
}
