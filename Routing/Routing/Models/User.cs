using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Routing.Models
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
        

    }
}