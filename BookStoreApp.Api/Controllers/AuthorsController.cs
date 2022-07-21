using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Api.Data;
using BookStoreApp.Api.Models.Author;
using AutoMapper;
using Microsoft.Extensions.Logging;
using BookStoreApp.Api.Static;
using Microsoft.AspNetCore.Authorization;
using AutoMapper.QueryableExtensions;
using BookStoreApp.Api.Repositories;
using BookStoreApp.Api.Models;

namespace BookStoreApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(IAuthorsRepository authorsRepository, IMapper mapper, ILogger<AuthorsController> logger)
        {
            this._authorsRepository = authorsRepository;
            this._mapper = mapper;
            this._logger = logger;
        }

        // GET: api/Authors/?startindex=0&pagesize=15
        [HttpGet]
        public async Task<ActionResult<VirtualizeResponse<AuthorReadOnlyDto>>> GetAuthors([FromQuery]QueryParameters queryParameters) // [FromQuery] params come from the URL
        {
            _logger.LogInformation($"Request to {nameof(GetAuthor)}");
            try
            {
                var authorDtos = await _authorsRepository.GetAllAsync<AuthorReadOnlyDto>(queryParameters);
                ///var authorDtos = _mapper.Map<IEnumerable<AuthorReadOnlyDto>>(authors); because we made the projection in the previous method
                return Ok(authorDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetAuthor)}");
                return StatusCode(500, Messages.Error500Message);
            }
            
        }

        // GET: api/Authors/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AuthorReadOnlyDto>>> GetAuthors()
        {
            _logger.LogInformation($"Request to {nameof(GetAuthor)}");
            try
            {
                var authors= await _authorsRepository.GetAllAsync();
                var authorDtos = _mapper.Map<IEnumerable<AuthorReadOnlyDto>>(authors); 
                return Ok(authorDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetAuthor)}");
                return StatusCode(500, Messages.Error500Message);
            }

        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailsDto>> GetAuthor(int id)
        {
            _logger.LogInformation($"Request to {nameof(GetAuthor)} which has ID: {id}");
            try
            {
                var author = await _authorsRepository.GetAuthorDetailsDtoAsync(id);

                if (author == null)
                {
                    _logger.LogWarning($"Reacord not found : {nameof(GetAuthor)} - ID: {id}");
                    return NotFound();
                }
                //var authorDto = _mapper.Map<AuthorReadOnlyDto>(author);
                return Ok(author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetAuthor)}");
                return StatusCode(500, Messages.Error500Message);
            }
            
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutAuthor(int id, AuthorUpdateDto authorDto)
        {
            if (id != authorDto.Id)
            {
                _logger.LogWarning($"Update ID invalid in {nameof(PutAuthor)} - ID: {id}");
                return BadRequest();
            }
            var author = await _authorsRepository.GetAsync(id); // Find Author with the provided Id
            // Ckeck if that record exist
            if (author == null)
            {
                _logger.LogWarning($"{nameof(author)} record not found in {nameof(PutAuthor)} - ID: {id}");
                return NotFound();
            }
            _mapper.Map(authorDto, author);    

            try
            {
                await _authorsRepository.UpdateAsync(author);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, $"Error performing PUT in {nameof(PutAuthor)}");
                    return StatusCode(500, Messages.Error500Message);
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<AuthorCreateDto>> PostAuthor(AuthorCreateDto authorDto)
        {
            //var author = new Author
            //{
            //    Bio = authorDto.Bio,
            //    FirstName = authorDto.FirstName,
            //    LastName = authorDto.LastName
            //};

            try
            {
                var author = _mapper.Map<Author>(authorDto); // more beta
                await _authorsRepository.AddAsync(author);

                return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing Post in {nameof(PostAuthor)}");
                return StatusCode(500, Messages.Error500Message);
            }            
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var author = await _authorsRepository.GetAsync(id);
                if (author == null)
                {
                    _logger.LogWarning($"{nameof(author)} record not found in {nameof(DeleteAuthor)} - ID: {id}");
                    return NotFound();
                }

                await _authorsRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing DELETE in {nameof(DeleteAuthor)}");
                return StatusCode(500, Messages.Error500Message);
            }
            
        }

        private async Task<bool> AuthorExists(int id)
        {
            return await _authorsRepository.Exists(id);
        }
    }
}
