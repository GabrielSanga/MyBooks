namespace MyBooks.Core.Authenticate
{
    public interface IAuthService
    {
        string CalcularHash(string senha);

        string GerarToken(string email);
    }
}
