using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookshelfAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book()
                {
                    Id = 1, Author = "Charles Duhigg", Name = "Habit", Description = "How to form life changing habits."
                },
                new Book()
                {
                    Id = 2, Author = "Jaime Levy", Name = "UX Strategy", Description = "A guide to UX strategy"
                },
                new Book()
                {
                    Id = 3, Author = "David Travis", Name = "Think Like a UX Researcher",
                    Description = "How to survive as a UXR."
                }
            };
        }
    }
}
