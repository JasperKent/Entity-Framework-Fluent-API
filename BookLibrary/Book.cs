using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int YearOfPublication { get; set; }
        public decimal Price { get; set; }

        public Author Author { get; set; }
    }
}
