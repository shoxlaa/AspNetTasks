namespace NewNotesApplication.Models
{
    public class Note
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string DateTime { get; set; }
        public string Tags { get; set; } = null!;

    }
}