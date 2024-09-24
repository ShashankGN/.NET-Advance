namespace Employees.API.Authetication
{
    public interface IJwtTokenManager
    {
        public string Authenticate(string userName, string password);
    }
}