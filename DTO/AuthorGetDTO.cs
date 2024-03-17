using BookshelfAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BookshelfAPI.DTO
{
    //public class AuthorGetDTO
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public List<Book> Books { get; } = [];
    //}
    public record AuthorGetDTO(
        int Id,
        string Name,
        List<Book> Books
    );
}
