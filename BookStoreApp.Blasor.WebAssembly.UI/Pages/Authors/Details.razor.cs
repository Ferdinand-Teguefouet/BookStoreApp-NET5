using BookStoreApp.Blazor.WebAssembly.UI.Services;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Pages.Authors
{
    public class DetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        protected IAuthorService AuthorService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected AuthorDetailsDto Author = new AuthorDetailsDto();

        protected async override Task OnInitializedAsync()
        {
            var response = await AuthorService.GetById(Id);
            if (response.Success)
            {
                Author = response.Data;
            }
        }

        protected void BackToList()
        {
            NavigationManager.NavigateTo("/authors/");
        }

        protected void GoToEdit()
        {
            NavigationManager.NavigateTo($"/authors/update/{Author.Id}");
        }
    }
}
