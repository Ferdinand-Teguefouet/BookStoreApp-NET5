using BookStoreApp.Blazor.Server.UI.Services;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using BookStoreApp.Blazor.Server.UI.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.Server.UI.Pages.Authors
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

        protected  void BackToList()
        {
            NavigationManager.NavigateTo("/authors/");
        }
    }
}
