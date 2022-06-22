using System.ComponentModel.DataAnnotations;
namespace LibraryBook.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Пользовательское имя")]
        public string? NicName { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}

