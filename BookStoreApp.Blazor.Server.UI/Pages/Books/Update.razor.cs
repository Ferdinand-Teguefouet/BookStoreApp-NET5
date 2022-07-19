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
    public class UpdateBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        private IBookService _bookService { get; set; }
        [Inject]
        private IAuthorService _authorService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected BookUpdateDto Book = new BookUpdateDto();
        protected List<AuthorReadOnlyDto> Authors = new();
        protected string UpLoadFileWarning = string.Empty;
        protected string img = string.Empty;
        private readonly long maxFileSize = 1024 * 1024 * 5;


        protected override async Task OnInitializedAsync()
        {
            var bookResponse = await _bookService.GetBookForUpdate(Id);
            if (bookResponse.Success)
            {
                Book = bookResponse.Data;
                img = Book.Image;
            }
            var Authorresponse = await _authorService.Get();
            if (Authorresponse.Success)
            {
                Authors = Authorresponse.Data;
            }
        }
        
        protected async Task HandleFileSelection(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file != null)
            {
                if (file.Size > maxFileSize)
                {
                    UpLoadFileWarning = "This file is too big for upload.";
                    return;
                }
                var ext = Path.GetExtension(file.Name);
                if ((ext.ToLower().Contains("jpg") || ext.ToLower().Contains("png") || ext.ToLower().Contains("jpeg")) == false)
                {
                    UpLoadFileWarning = "Please select a valid image file (*.jpg | *.png | *.jpeg)";
                    return;
                }

                var byteArray = new byte[file.Size];
                await file.OpenReadStream().ReadAsync(byteArray);
                string imageType = file.ContentType;
                string base64String = Convert.ToBase64String(byteArray);

                Book.ImageData = base64String;
                Book.OriginalImageName = file.Name;
                img = $"data: {imageType}; base64, {base64String}";
            }
        }

        protected async Task HandleBookUpdate()
        {
            var response = await _bookService.Edit(Id, Book);
            if (response.Success)
            {
                BackToList();
            }
        }

        protected void BackToList()
        {
            NavigationManager.NavigateTo("/books/");
        }
    }
}
