using BookStoreApp.Blazor.WebAssembly.UI.Services;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Pages.Books
{
    public class DetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        protected IBookService BookService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected BookDetailsDto Book = new BookDetailsDto();

        protected async override Task OnInitializedAsync()
        {
            var response = await BookService.GetById(Id);
            if (response.Success)
            {
                Book = response.Data;
            }
        }

        protected void BackToList()
        {
            NavigationManager.NavigateTo("/books/");
        }

        protected void GoToEdit()
        {
            NavigationManager.NavigateTo($"/books/update/{Book.Id}");
        }

    }
}
