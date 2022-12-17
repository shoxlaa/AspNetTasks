using System.ComponentModel.DataAnnotations;

namespace WebApiMystat.Models;

public class HomeWork
{
    [Key]
    public int Id { get; set; }
    [MaxLength(450)]
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public string File { get; set; }

}