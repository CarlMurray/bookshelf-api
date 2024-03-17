using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookshelfAPI.Models
{
    [Table("Authors")]
    public class Author
    {
        [Key][Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public List<Book> Books { get; } = [];
    }
}
