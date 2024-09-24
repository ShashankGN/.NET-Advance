namespace Authenticat.Microservice.Authenticate
{
    public interface IJwtTokenManager
    {
        public string Authenticate(string userName, string password);
    }
}
