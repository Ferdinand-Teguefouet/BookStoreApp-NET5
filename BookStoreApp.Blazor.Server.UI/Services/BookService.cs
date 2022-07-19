using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        private readonly IClient _client;
        private readonly IMapper _mapper;

        public BookService(IClient client, ILocalStorageService localStorageService, IMapper mapper) : base(client, localStorageService)
        {
            this._client = client;
            this._mapper = mapper;
        }

        public async Task<Response<List<BookReadOnlyDto>>> Get()
        {
            Response<List<BookReadOnlyDto>> response;

            try
            {
                await GetBearerToken();
                var data = await _client.BooksAllAsync();
                response = new Response<List<BookReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<List<BookReadOnlyDto>>(exception);
            }

            return response;
        }

        public async Task<Response<int>> Create(BookCreateDto book)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await _client.BooksPOSTAsync(book);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<int>> Edit(int id, BookUpdateDto book)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await _client.BooksPUTAsync(id, book);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<BookDetailsDto>> GetById(int Id)
        {
            Response<BookDetailsDto> response;

            try
            {
                await GetBearerToken();
                var data = await _client.BooksGETAsync(Id);
                response = new Response<BookDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<BookDetailsDto>(exception);
            }

            return response;
        }

        public async Task<Response<BookUpdateDto>> GetBookForUpdate(int Id)
        {
            Response<BookUpdateDto> response;

            try
            {
                await GetBearerToken();
                var data = await _client.BooksGETAsync(Id);
                response = new Response<BookUpdateDto>
                {
                    Data = _mapper.Map<BookUpdateDto>(data),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<BookUpdateDto>(exception);
            }

            return response;
        }

        public async Task<Response<int>> Delete(int Id)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await _client.BooksDELETEAsync(Id);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }
    }
}
