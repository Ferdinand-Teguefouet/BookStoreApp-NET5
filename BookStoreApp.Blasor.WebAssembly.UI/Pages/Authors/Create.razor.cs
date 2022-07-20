using BookStoreApp.Blazor.WebAssembly.UI.Services;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Pages.Authors
{
    public class CreateBase : ComponentBase
    {
        [Inject]
        protected IAuthorService AuthorService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected AuthorCreateDto Author = new AuthorCreateDto();

        protected async Task HandleCreateAuthor()
        {
            var response = await AuthorService.Create(Author);
            if (response.Success)
            {
                BackToList();
            }
        }

        protected void BackToList()
        {
            NavigationManager.NavigateTo("/authors/");
        }
    }
}

