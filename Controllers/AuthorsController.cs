using BookshelfAPI.DTO;
using BookshelfAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookshelfAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly ApplicationDbContext _context;

        public AuthorsController(ApplicationDbContext context, ILogger<AuthorsController> logger)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/authors
        /// <summary>
        /// Gets all Authors.
        /// </summary>
        [HttpGet]
        public ActionResult<RestDTO<AuthorGetDTO[]>> Get()
        {
            var authors = _context.Authors;
            List<AuthorGetDTO> authorsDtos = [];
            foreach (var author in authors)
            {
                var authorDto = new AuthorGetDTO(author.Id, author.Name);
                authorsDtos.Add(authorDto);
            }

            return new RestDTO<AuthorGetDTO[]>()
            {
                Data = authorsDtos.ToArray(),
                Links =
                [
                    new LinkDTO(Url.Action(action: "Get", controller: "Authors", null, Request.Scheme)!, "self", "GET")
                ]
            };
        }

        // PUT api/authors/5
        /// <summary>
        /// Edits an Author.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Put(int id, AuthorCreateDTO authorDto)
        {
            Author author;
            var authors = _context.Authors;

            // Check ID is valid
            try
            {
                author = authors.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                return NotFound("Object does not exist.");
            }

            // Check string is valid
            if (string.IsNullOrWhiteSpace(authorDto.Name))
            {
                // Failed validation message
                return ValidationProblem("Name must not be empty or whitespace.");
            }
            author.Name = authorDto.Name;
            _context.SaveChanges();
            return Ok();

        }

        // POST api/authors
        /// <summary>
        /// Creates a new Author.
        /// </summary>
        [HttpPost]
        public ActionResult Post(AuthorCreateDTO authorDto)
        {
            var authors = _context.Authors;

            if (string.IsNullOrWhiteSpace(authorDto.Name))
            {
                // Failed validation message
                return ValidationProblem("Name must not be empty or whitespace.");
            }
            var author = new Author()
            {
                Name = authorDto.Name
            };
            authors.Add(author);
            _context.SaveChanges();
            return Ok(author);
        }


        // DELETE api/authors/5
        /// <summary>
        /// Deletes an Author.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var authors = _context.Authors;

            // Check ID is valid
            try
            {
                var author = authors.First(a => a.Id == id);
                authors.Remove(author);
            }
            catch (Exception e)
            {
                return NotFound("Object does not exist.");
            }
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/authors/delete_all
        /// <summary>
        /// Deletes all Authors.
        /// </summary>
        [HttpDelete("delete_all")]
        public async Task<ActionResult> DeleteAll()
        {
            var authors = _context.Authors;
            if (!authors.IsNullOrEmpty())
            {

                foreach (var author in authors)
                {
                    authors.Remove(author);
                }

                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound("No authors to delete.");
            }
        }
    }
}
