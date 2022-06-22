using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryBook.Models
{
    public class BookAut
    {
        [Key]
        [Column(Order = 1)]
        public int AuthorId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int BookId { get; set; }
        public Author? Authors { get; set; }
        public Book? Books { get; set; }
    }
}
