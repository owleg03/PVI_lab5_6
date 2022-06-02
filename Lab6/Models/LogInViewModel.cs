using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class LogInViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
