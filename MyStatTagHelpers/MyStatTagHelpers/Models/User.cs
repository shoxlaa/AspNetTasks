using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyStatTagHelpers.Models
{
    [Index("Name", IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(450)]

        public string Name { get; set; }
        [MaxLength(450)]
        public string? Surname { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }

    }
}
