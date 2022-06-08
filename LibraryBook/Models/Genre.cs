using System.ComponentModel.DataAnnotations;
namespace LibraryBook.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Жанр")]
        public string? Name { get; set; }
    }
}
