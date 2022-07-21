using BookStoreApp.Blazor.Server.UI.Models;
using BookStoreApp.Blazor.Server.UI.Services;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.Server.UI.Pages.Authors
{
    public class IndexBase : ComponentBase
    {
        public List<AuthorReadOnlyDto> Authors;
        public int TotalSize { get; set; }
        protected Response<AuthorReadOnlyDtoVirtualizeResponse> Response = new Response<AuthorReadOnlyDtoVirtualizeResponse> {Success = true };

        [Inject]
        private IAuthorService _authorService { get; set; }

        [Inject]
        private IJSRuntime _jSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Response = await _authorService.Get(new QueryParameters {StartIndex = 0});
            if (Response.Success)
            {
                Authors = Response.Data.Items.ToList();
            }
        }

        protected async Task LoadAuthors(QueryParameters queryParams)
        {
            var virtualizeResult = await _authorService.Get(queryParams);
            Authors = virtualizeResult.Data.Items.ToList();
            TotalSize = virtualizeResult.Data.TotalSize;
        }
    }
}
