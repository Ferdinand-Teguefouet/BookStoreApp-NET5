using BookStoreApp.Blazor.Server.UI.Models;
using BookStoreApp.Blazor.Server.UI.Services;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.Server.UI.Pages.Authors
{
    public class AuthorTableBase : ComponentBase
    {
        [Parameter]
        public List<AuthorReadOnlyDto> Authors { get; set; }
        [Parameter]
        public int TotalSize { get; set; }
        [Parameter]
        public EventCallback<QueryParameters> OnScroll { get; set; }
        protected Response<List<AuthorReadOnlyDto>> Response = new Response<List<AuthorReadOnlyDto>> { Success = true };

        [Inject]
        private IAuthorService _authorService { get; set; }

        [Inject]
        private IJSRuntime _jSRuntime { get; set; }


        protected async ValueTask<ItemsProviderResult<AuthorReadOnlyDto>> LoadAuthors(ItemsProviderRequest request)
        {
            var productNum = Math.Min(request.Count, TotalSize - request.StartIndex); // Calculate the minimum number to start
            await OnScroll.InvokeAsync(new QueryParameters { // what method to call we InvokeAsync? LoadAuthors
                StartIndex = request.StartIndex,
                PageSize = productNum == 0 ? request.Count : productNum
            });
            return new ItemsProviderResult<AuthorReadOnlyDto>(Authors, TotalSize);
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
