using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookshelfAPI.Models
{
    [Table("Books")]
    public class Book
    {
        [Key][Required] public int Id { get; set; }

        [Required][MaxLength(200)] public string Title { get; set; }
        [Required][MaxLength(3000)] public string Description { get; set; }
        [Required][MaxLength(10)] public string ISBN { get; set; }
        [Required] public DateTime PublishDate { get; set; }
        [Required] public int NumPages { get; set; }
        public List<Author> Authors { get; } = [];
    }
}
