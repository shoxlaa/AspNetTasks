using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace REST_API.Models
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


    public class HomeWork
    {

    }
}
