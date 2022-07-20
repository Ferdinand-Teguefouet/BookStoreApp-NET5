using BookStoreApp.Blazor.WebAssembly.UI.Services.Authentication;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Pages.Users
{
    public class LoginBase : ComponentBase
    {
        protected LoginUserDto LoginModel = new LoginUserDto();
        protected string message = string.Empty;

        [Inject]
        protected NavigationManager NavigationManager { get; set; }


        [Inject]
        protected IAuthenticationService _authService { get; set; }

        protected async Task HandleLogin()
        {
            try
            {
                var response = await _authService.AuthenticateAsync(LoginModel);
                if (response)
                {
                    NavigationManager.NavigateTo("/");
                }
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode >= 400 && ex.StatusCode <= 500)
                {
                    message = "Invalid Credentials, Please Try Again";                    
                }
                message = ex.Response;
            }
        }
    }
}
