using System.ComponentModel.DataAnnotations;
namespace LibraryBook.Models
{
    public class Rate
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Оценка")]
        public string? Name { get; set; }
    }
}
