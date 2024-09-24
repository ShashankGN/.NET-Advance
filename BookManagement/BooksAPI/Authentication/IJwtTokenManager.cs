namespace BooksAPI.Authentication
{
    public interface IJwtTokenManager
    {
        public string Authenticate(string userName, string password);
    }
}