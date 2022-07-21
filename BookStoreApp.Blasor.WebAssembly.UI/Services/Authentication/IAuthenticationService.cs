using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<Response<AuthResponse>> AuthenticateAsync(LoginUserDto loginModel);
        Task Logout();
    }
}
