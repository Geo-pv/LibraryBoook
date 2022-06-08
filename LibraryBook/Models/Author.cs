using System.ComponentModel.DataAnnotations;

namespace LibraryBook.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string? Surname { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string? MiddleName { get; set; }
        public List<Book> Book { get; set; }
        public Author()
        {
            Book = new List<Book>();
        }

    }
}
