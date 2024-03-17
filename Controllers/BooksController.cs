using BookshelfAPI.DTO;
using BookshelfAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookshelfAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context, ILogger<BooksController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
        public async Task<RestDTO<BookGetDTO[]>> Get()
        {
            var query = _context.Books;
            var books = await query.ToListAsync();
            List<BookGetDTO> bookDtos = [];
            foreach (var book in books)
            {
                var item = new BookGetDTO()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    ISBN = book.ISBN,
                    NumPages = book.NumPages,
                    Authors = book.Authors,
                    PublishDate = book.PublishDate
                };
                bookDtos.Add(item);
            }
            return new RestDTO<BookGetDTO[]>()
            {
                Data = bookDtos.ToArray(),
                Links =
                [
                    new LinkDTO(Url.Action(action: "Get", controller: "Books", null, Request.Scheme)!, "self", "GET")
                ]
            };
        }

        [HttpPost]
        public async Task<ActionResult<BookCreateDTO>> Post(BookCreateDTO bookDto)
        {
            var query = _context.Books;

            // Create new book
            var book = new Book()
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                NumPages = bookDto.NumPages,
                PublishDate = bookDto.PublishDate.Date,
                ISBN = bookDto.ISBN
            };

            // Get the Authors from dbcontext
            var authors = await _context.Authors.Where(a => bookDto.AuthorIds.Contains(a.Id)).ToListAsync();

            // Add the authors to book
            foreach (var author in authors)
            {
                book.Authors.Add(author);
            }

            // Add book to db
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), new { id = book.Id }, book);
        }
    }
}
