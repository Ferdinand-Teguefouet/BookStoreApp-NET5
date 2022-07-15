using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.Server.UI.Shared
{
    public class RedirectToLoginBase : ComponentBase
    {
        protected NavigationManager Navigation { get; set; }
        protected override void OnInitialized()
        {
            Navigation.NavigateTo("/users/login");
        }
    }
}
