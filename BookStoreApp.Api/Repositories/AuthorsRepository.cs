using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.Api.Data;
using BookStoreApp.Api.Models.Author;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStoreApp.Api.Repositories
{
    public class AuthorsRepository : GenericRepository<Author>, IAuthorsRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsRepository(BookStoreDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<AuthorDetailsDto> GetAuthorDetailsDtoAsync(int id)
        {
            var author = await _context.Authors
                .Include(x => x.Books)
                .ProjectTo<AuthorDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);

            return author;
        }
    }
}
