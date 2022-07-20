using BookStoreApp.Blazor.WebAssembly.UI.Services.Authentication;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Pages.Users
{
    
    public class LogoutBase : ComponentBase
    {
        [Inject]
        protected IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected async  override Task OnInitializedAsync()
        {
            await AuthenticationService.Logout();
            NavigationManager.NavigateTo("/");
        }
    }
}
