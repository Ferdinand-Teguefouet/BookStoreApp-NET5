using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services
{
    public interface IBookService
    {
        Task<Response<List<BookReadOnlyDto>>> Get();
        Task<Response<BookDetailsDto>> GetById(int Id);
        Task<Response<BookUpdateDto>> GetBookForUpdate(int Id);
        Task<Response<int>> Create(BookCreateDto author);
        Task<Response<int>> Edit(int Id, BookUpdateDto author);
        Task<Response<int>> Delete(int Id);
    }
}