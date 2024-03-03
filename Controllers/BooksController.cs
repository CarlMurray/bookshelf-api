using BookshelfAPI.DTO;
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
        public RestDTO<Book[]> GetBooks()
        {
            return new RestDTO<Book[]>()
            {
                Data = new Book[] {
                new()
                {
                    Id = 1, Author = "Charles Duhigg", Name = "Habit", Description = "How to form life changing habits."
                },
                new()
                {
                    Id = 2, Author = "Jaime Levy", Name = "UX Strategy", Description = "A guide to UX strategy"
                },
                new()
                {
                    Id = 3, Author = "David Travis", Name = "Think Like a UX Researcher",
                    Description = "How to survive as a UXR."
                }

                },

                Links =
                [
                    new LinkDTO(Url.Action(action: "GetBooks", controller: "Books", null, Request.Scheme)!, "self", "GET")
                ]
            };
        }
    }
}
