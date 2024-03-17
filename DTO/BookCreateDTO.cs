using BookshelfAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BookshelfAPI.DTO
{
    public class BookCreateDTO
    {
        public string Title { get; private set; }
        public string Description {get; private set;}
        public string ISBN {get; private set;}
        public DateTime PublishDate {get; private set;}
        public int NumPages {get; private set;}
        public List<int> AuthorIds {get; private set;}
    }

}
