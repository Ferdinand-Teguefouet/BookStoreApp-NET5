using BookStoreApp.Blazor.Server.UI.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorReadOnlyDto>>> Get();
        Task<Response<AuthorDetailsDto>> GetById(int Id);
        Task<Response<AuthorUpdateDto>> GetAuthorForUpdate(int Id);
        Task<Response<int>> Create(AuthorCreateDto author);
        Task<Response<int>> Edit(int Id,AuthorUpdateDto author);
        Task<Response<int>> Delete(int Id);
    }
}