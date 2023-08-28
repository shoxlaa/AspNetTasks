namespace CinemaApp.Models
{
    public class Session : IModel
    {
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public DateTime dateTime { get; set; }

    }
}