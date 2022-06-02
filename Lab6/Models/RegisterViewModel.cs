using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public enum Level { Begginer, Intermediate, Advanced, Pro }
    public class RegisterViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public int Age { get; set; }

        public string? Gender { get; set; }
        public Level? Level { get; set; }
        public string? About { get; set; }
        public string? Avatar { get; set; }
    }
}
