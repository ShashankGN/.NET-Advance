using Jwt_Authenticatoin_Authorization.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Authenticatoin_Authorization.Contracts
{
    public interface IAuth
    {
        public Task<object> CheckLoginCred(Login model);

        public Task<Response> UserRegister(Register model);

        public Task<Response> AdminRegister(Register model);

    }
}
