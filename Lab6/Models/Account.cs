using Microsoft.AspNetCore.Mvc;

namespace Lab6.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Level { get; set; }
        public string? About { get; set; }
        public string? Avatar { get; set; }
    }
}
