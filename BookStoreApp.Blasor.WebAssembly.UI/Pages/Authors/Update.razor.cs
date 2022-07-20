using BookStoreApp.Blazor.WebAssembly.UI.Services;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Pages.Authors
{
    public class UpdateBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        protected IAuthorService AuthorService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected AuthorUpdateDto Author = new AuthorUpdateDto();

        protected async override Task OnInitializedAsync()
        {
            var response = await AuthorService.GetAuthorForUpdate(Id);
            if (response.Success)
            {
                Author = response.Data;
            }
        }

        protected async Task HandleUpdateAuthor()
        {
            var response = await AuthorService.Edit(Id, Author);
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
