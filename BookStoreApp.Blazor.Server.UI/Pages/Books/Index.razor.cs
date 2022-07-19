using BookStoreApp.Blazor.Server.UI.Services;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.Server.UI.Pages.Books
{
    public class IndexBase : ComponentBase
    {
        protected List<BookReadOnlyDto> Books;
        protected Response<List<BookReadOnlyDto>> Response = new Response<List<BookReadOnlyDto>> { Success = true };

        [Inject]
        private IBookService _bookService { get; set; }

        [Inject]
        private IJSRuntime _jSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {            
            Response = await _bookService.Get();
            if (Response.Success)
            {
                Books = Response.Data;
            }
        }

        protected async Task Delete(int bookId)
        {
            var book = Books.First(x => x.Id == bookId);
            var confirm = await _jSRuntime.InvokeAsync<bool>("confirm", $"Are You Sure You Want To Delete {book.Title}?");
            if (confirm)
            {
                var response = await _bookService.Delete(bookId);
                if (response.Success)
                {
                    await OnInitializedAsync();
                }
            }

        }
    }
}
