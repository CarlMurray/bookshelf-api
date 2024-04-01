using BookshelfAPI.DTO;
using BookshelfAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Nodes;

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

        /// <summary>
        /// Gets all Books.
        /// </summary>
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
        public async Task<RestDTO<BookGetDTO[]>> Get()
        {
            var query = _context.Books;
            var books = await query.Include(b => b.Authors).ToListAsync();
            List<BookGetDTO> bookDtos = [];
            foreach (var book in books)
            {
                var bookDtoAuthors = new List<AuthorGetDTO>();
                foreach (var author in book.Authors)
                {
                    var _author = new AuthorGetDTO(author.Id, author.Name);
                    bookDtoAuthors.Add(_author);
                }

                var item = new BookGetDTO(book.Id, book.Title, book.Description, book.ISBN, book.PublishDate,
                    book.NumPages, bookDtoAuthors);

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

        [HttpGet("{id}")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
        public async Task<IActionResult> GetBook(int id)
        {
            var query = _context.Books;
            var book = await query.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);

            var bookDtoAuthors = new List<AuthorGetDTO>();

            foreach (var author in book.Authors)
            {
                var _author = new AuthorGetDTO(author.Id, author.Name);
                bookDtoAuthors.Add(_author);
            }

            var item = new BookGetDTO(book.Id, book.Title, book.Description, book.ISBN, book.PublishDate,
                book.NumPages, bookDtoAuthors);

            return Ok(item);
        }

        /// <summary>
        /// Creates a new Book.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<BookCreateDTO>> Post(BookCreateDTO bookDto)
        {
            Console.WriteLine(bookDto.AuthorIds);
            var query = _context.Books;
            var authors = await _context.Authors.Where(a => bookDto.AuthorIds.Contains(a.Id)).ToListAsync();

            // Create new book
            var book = new Book()
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                NumPages = bookDto.NumPages,
                PublishDate = bookDto.PublishDate.Date,
                ISBN = bookDto.ISBN,
                Authors = new List<Author>()
            };

            // Add the authors to book
            foreach (var author in authors)
            {
                book.Authors.Add(author);
            }

            // Add book to db
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// Edits a Book.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<BookCreateDTO>> Put(int id, BookCreateDTO bookDto=null)
        {
            var books = _context.Books;
            List<Author> authors = null;
            if(bookDto.AuthorIds != null)
            {
             authors = await _context.Authors.Where(a => bookDto.AuthorIds.Contains(a.Id)).ToListAsync();
            }

            Book book;
            // get the id user entered
            // find the book it relates to
            // update the data for that book
            try
            {
                book = books.First(a => a.Id == id);

            }
            catch (Exception e)
            {
                return NotFound("Object doesn't exist.");
            }
            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.ISBN = bookDto.ISBN;
            //book.Authors = authors;
            book.NumPages = bookDto.NumPages;
            book.PublishDate = bookDto.PublishDate;
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Deletes a Book.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult<BookGetDTO> Delete(int id)
        {
            var books = _context.Books;
            try
            {
                var book = books.First(b => b.Id == id);
                books.Remove(book);
            }
            catch (Exception e)
            {
                return NotFound("Object does not exist.");
            }

            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Deletes all books.
        /// </summary>
        [HttpDelete("delete_all")]
        public async Task<ActionResult> DeleteAll()
        {
            var books = _context.Books;
            foreach (var book in books)
            {
                books.Remove(book);
            }

            _context.SaveChangesAsync();

            return Ok();
        }
    }
}