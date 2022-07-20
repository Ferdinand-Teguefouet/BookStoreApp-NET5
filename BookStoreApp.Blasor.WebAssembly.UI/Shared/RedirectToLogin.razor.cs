using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Shared
{
    public class RedirectToLoginBase : ComponentBase
    {
        private readonly NavigationManager Navigation;
        protected override void OnInitialized()
        {
            Navigation.NavigateTo("users/login");
        }
    }
}
