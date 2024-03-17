using BookshelfAPI.DTO;
using BookshelfAPI.Models;
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
          

                },

                Links =
                [
                    new LinkDTO(Url.Action(action: "GetBooks", controller: "Books", null, Request.Scheme)!, "self", "GET")
                ]
            };
        }
    }
}
