using BookStoreApp.Blazor.WebAssembly.UI.Services;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Pages.Authors
{
    public class IndexBase : ComponentBase
    {
        protected List<AuthorReadOnlyDto> Authors;
        protected Response<List<AuthorReadOnlyDto>> Response = new Response<List<AuthorReadOnlyDto>> { Success = true };

        [Inject]
        private IAuthorService _authorService { get; set; }

        [Inject]
        private IJSRuntime _jSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Response = await _authorService.Get();
            if (Response.Success)
            {
                Authors = Response.Data;
            }
        }

        protected async Task Delete(int authorId)
        {
            var author = Authors.First(x => x.Id == authorId);
            var confirm = await _jSRuntime.InvokeAsync<bool>("confirm", $"Are You Sure You Want To Delete {author.FirstName} {author.LastName}?");
            if (confirm)
            {
                var response = await _authorService.Delete(authorId);
                if (response.Success)
                {
                    await OnInitializedAsync();
                }
            }

        }
    }
}

