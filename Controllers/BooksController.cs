﻿using BookshelfAPI.DTO;
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


        [HttpPost]
        public async Task<ActionResult<BookCreateDTO>> Post(BookCreateDTO bookDto)
        {
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
                //Authors = authors
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
    }
}