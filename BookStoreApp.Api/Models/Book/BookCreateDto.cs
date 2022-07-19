using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Api.Models.Book
{
    public class BookCreateDto // we don't need to inherit from BaseDto because we don't need hte ID if created a book
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [Range(1800, int.MaxValue)]
        public int Year { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Summary { get; set; }

        public string? ImageData { get; set; }
        public string? OriginalImageName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
