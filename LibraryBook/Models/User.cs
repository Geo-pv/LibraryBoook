using System.ComponentModel.DataAnnotations;
namespace LibraryBook.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string? Name { get; set; }
        public int idRole { get; set; }
        [Required]
        [Display(Name = "Логин")]
        public int Login { get; set; }
        [Required]
        [Display(Name = "Пользовательское имя")]
        public string? NicName { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        public int Password { get; set; }
    }
}

