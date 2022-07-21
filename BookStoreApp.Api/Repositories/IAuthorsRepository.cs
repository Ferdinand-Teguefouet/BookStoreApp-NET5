using BookStoreApp.Api.Data;
using BookStoreApp.Api.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Api.Repositories
{
    public interface IAuthorsRepository : IGenericRepository<Author>
    {
        Task<AuthorDetailsDto> GetAuthorDetailsDtoAsync(int id);
    }
}
