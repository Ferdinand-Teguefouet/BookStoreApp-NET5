using BookStoreApp.Blazor.Server.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.Server.UI.Pages.Users
{
    public class RegisterBase : ComponentBase
    {
        protected UserDto RegistrationModel = new UserDto { Role = "User"};
        protected string message = string.Empty;

        [Inject]
        protected IClient _httpClient { get; set; }

        [Inject]
        protected NavigationManager _navManager { get; set; }

        protected async Task HandleRegistration()
        {
            RegistrationModel.Role = "User";
            try
            {
                await _httpClient.RegisterAsync(RegistrationModel);
                NavigateToLogin();
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode >= 200 && ex.StatusCode <= 299)
                {
                    NavigateToLogin();
                }
                message = ex.Response;
            }
        }

        private void NavigateToLogin()
        {
            _navManager.NavigateTo("users/login");
        }
    }
}
