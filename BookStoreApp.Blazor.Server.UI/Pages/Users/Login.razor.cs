using BookStoreApp.Blazor.Server.UI.Services.Authentication;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.Server.UI.Pages.Users
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
            var response = await _authService.AuthenticateAsync(LoginModel);
            if (response.Success)
            {
                NavigationManager.NavigateTo("/");
            }
            message = response.Message;              
        }
    }
}
