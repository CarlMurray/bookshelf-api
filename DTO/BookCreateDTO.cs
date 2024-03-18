using BookshelfAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BookshelfAPI.DTO
{
    public record BookCreateDTO(
        string Title,
        string Description,
        string ISBN,
        DateTime PublishDate,
        int NumPages,
        List<int> AuthorIds
    );

}
