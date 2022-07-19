using BookStoreApp.Blazor.Server.UI.Services;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.Server.UI.Pages.Books
{
    public class CreateBase : ComponentBase
    {
        [Inject]
        private IBookService _bookService { get; set; }
        [Inject]
        private IAuthorService _authorService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected BookCreateDto Book = new BookCreateDto();
        protected List<AuthorReadOnlyDto> Authors = new();
        protected string UpLoadFileWarning = string.Empty;
        protected string img = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            var response = await _authorService.Get();
            if (response.Success)
            {
                Authors = response.Data;
            }
        }
        protected async Task HandleBookCreate()
        {
            var response = await _bookService.Create(Book);
            if (response.Success)
            {
                BackToList();
            }
        }

        protected async Task HandleFileSelection(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file != null)
            {
                var ext = Path.GetExtension(file.Name);
                if (ext.ToLower().Contains("jpg") || ext.ToLower().Contains("png") || ext.ToLower().Contains("jpeg"))
                {
                    var byteArray = new byte[file.Size];
                    await file.OpenReadStream().ReadAsync(byteArray);
                    string imageType = file.ContentType;
                    string base64String = Convert.ToBase64String(byteArray);

                    Book.ImageData = base64String;
                    Book.OriginalImageName = file.Name;
                    img = $"data: {imageType}; base64, {base64String}";
                }
                else
                {
                    UpLoadFileWarning = "Please select a valid image file (*.jpg | *.png | *.jpeg";
                }
            }
        }

        protected void BackToList()
        {
            NavigationManager.NavigateTo("/books/");
        }
    }
}
