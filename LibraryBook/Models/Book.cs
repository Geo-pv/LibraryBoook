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
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Количество страниц")]
        public uint Pages { get; set; }
        [Display(Name = "Обложка книги")]

        public string? Image { get; set; }
        [Display(Name = "Текст книги")]

        public string? TextFile { get; set; }

        [Display(Name = "Автор")]
        public int? AuthorId { get; set; }

        public Author? Author { get; set; }
    }
}

