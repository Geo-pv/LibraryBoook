using System.ComponentModel.DataAnnotations;
namespace LibraryBook.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string? Title { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Количество страниц")]
        public uint Pages { get; set; }

        [Required]
        [Display(Name = "Автор")]
        public int IdAuthor { get; set; }

        public Author? Author { get; set; }
    }
}

