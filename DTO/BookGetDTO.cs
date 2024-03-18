using BookshelfAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BookshelfAPI.DTO
{
    //public class BookGetDTO
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //    public string ISBN { get; set; }
    //    public DateTime PublishDate { get; set; }
    //    public int NumPages { get; set; }
    //    public List<Author> Authors { get; set; }
    //}

    public record BookGetDTO(
        int Id,
        string Title,
        string Description,
        string ISBN,
        DateTime PublishDate,
        int NumPages,
        List<AuthorGetDTO> Authors
    );

}
