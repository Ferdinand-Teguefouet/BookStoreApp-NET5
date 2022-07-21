using BookStoreApp.Api.Data;
using BookStoreApp.Api.Models.Book;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Api.Repositories
{
    public interface IBooksRepository : IGenericRepository<Book>
    {
        Task<List<BookReadOnlyDto>> GetAllBooksAsync();
        Task<BookDetailsDto> GetBookAsync(int id);
    }
}
