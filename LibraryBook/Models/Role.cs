using System.ComponentModel.DataAnnotations;
namespace LibraryBook.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Роль")]
        public string? Name { get; set; }
    }
}
